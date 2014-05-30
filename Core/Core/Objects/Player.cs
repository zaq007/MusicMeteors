using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Core.Misc;
using Microsoft.Xna.Framework.Graphics;
using GlobalHandlers.Mouse;
using GlobalHandlers.Keyboard;
using Microsoft.Xna.Framework.Input;
using Core.Controllers;
using System.Timers;

namespace Core.Objects
{
    public class Player : GameObject
    {
        Color color = Color.Red;
        public int Lives { get; set; }
        public bool isMoving { get; set; }
        public bool isRespawning { get; set; }
        public Player()
            : base(TextureLoader.Player, new Vector2(100, 100))
        {
            isMoving = false;
            Tag = "Player";
            KeyboardHandler.OnPress += OnPress;
            MouseHandler.OnClick += OnPress;
            MaxSpeed = 1.7f;
            Lives = 3;
            isRespawning = false;
        }

        /// <summary>
        /// Keyboard clicks handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPress(object sender, KeyboardEventArg e)
        {
            if (Alive)
            {
                Speed = new Vector2(0);
                if (e.pressed.Contains(Keys.W))
                {
                    isMoving = true;
                    Speed += new Vector2(0, -MaxSpeed);
                }
                if (e.pressed.Contains(Keys.D))
                {
                    isMoving = true;
                    Speed += new Vector2(MaxSpeed, 0);
                }
                if (e.pressed.Contains(Keys.S))
                {
                    isMoving = true;
                    Speed += new Vector2(0, MaxSpeed);
                }
                if (e.pressed.Contains(Keys.A))
                {
                    isMoving = true;
                    Speed += new Vector2(-MaxSpeed, 0);
                }
                Speed.Normalize();
                Speed *= MaxSpeed;

                if (e.clicked.Contains(Keys.A) || e.clicked.Contains(Keys.S) || e.clicked.Contains(Keys.D) || e.clicked.Contains(Keys.W))
                {
                    isMoving = false;
                    Speed = new Vector2(0);
                }
            }
        }

        
        void OnPress(object sender, MouseAgrs e)
        {
            if (!Alive)
                return;
            if (e.ClickedKey == Key.Left)
            {
                var k = ObjectContainer.Instance.TryGet(typeof(Bullet));
                if (k == null)
                {
                    ObjectContainer.Instance.Add(new Bullet(this.Position, Vector2.Normalize(new Vector2(MouseHandler.previous.X, MouseHandler.previous.Y) - Position)));
                }
                else
                {
                    k.Position = this.Position;
                    k.Speed = Vector2.Normalize(new Vector2(MouseHandler.previous.X, MouseHandler.previous.Y) - Position)*6;
                    k.Free = false;
                }
            }
        }

        public override void OnColision(object sender, ColisionArgs e)
        {
            if (e.fhhgf == this)
            {
                if (sender.GetType() == typeof(Meteor) && isRespawning == false && Alive == true && (sender as GameObject).Free == false)
                {
                    (sender as GameObject).Free = true;
                    (MainController.Instance.GetByName("ParticleController") as Particles.ParticleController).Boom(this.Position);
                    isRespawning = true;
                    Lives--;
                    Alive = false;
                    if (Lives > 0)
                    {
                        Position = new Vector2(256 * 2.5f, 256);
                        Timer t = new Timer(1500);
                        t.Elapsed += delegate
                        {
                            Alive = true;
                            Timer a = new Timer(1500);
                            a.Elapsed += delegate
                            {
                                isRespawning = false;
                            };
                            a.AutoReset = false;
                            a.Start();
                        };
                        t.AutoReset = false;
                        t.Start();
                    }
                    else
                    {

                        ObjectContainer.Instance.Add(new GameObject(TextureLoader.GameOver, new Vector2(256 * 2.5f, 256), Color.Yellow));
                        Timer t = new Timer(10000);
                        t.Elapsed += delegate
                        {
                            Return.Message = "DEAD";
                        };
                        t.AutoReset = false;
                        t.Start();
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 direction = Vector2.Normalize(new Vector2(MouseHandler.previous.X, MouseHandler.previous.Y) - Position);
            Angle = (float)Math.Atan2((double)direction.Y, (double)direction.X);

            var position = Position + Speed;
            if (position.X > 5 * 256 - 20 || position.Y > 2 * 256 - 50 || position.X < 10 || position.Y < 10)
                Position = new Vector2((position.X > 5 * 256 - 20) ? (5 * 256 - 20) : ((position.X < 10) ? 10 : position.X), (position.Y > 2 * 256 - 50) ? (2 * 256 - 50) : ((position.Y < 10) ? 10 : position.Y));
            else
                Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            if (isMoving == true)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.MotionBlur);
                TextureLoader.MotionBlur.Parameters["Angle"].SetValue((float)Math.Atan2(Speed.Y, Speed.X));
                base.Draw(spriteBatch, render);
                spriteBatch.End();
                spriteBatch.Begin();
            } else
                base.Draw(spriteBatch, render);

        }




    }
}
