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

namespace Core.Objects
{
    public class Player : GameObject
    {
        public bool isMoving { get; set; }
        public Player()
            : base(TextureLoader.Player, new Vector2(100, 100))
        {
            isMoving = false;
            Tag = "Player";
            KeyboardHandler.OnPress += OnPress;
            MaxSpeed = 1.7f;
        }

        void OnPress(object sender, KeyboardEventArg e)
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

        public override void Update(GameTime gameTime)
        {
            Vector2 direction = Vector2.Normalize(new Vector2(MouseHandler.previous.X, MouseHandler.previous.Y) - Position);
            Angle = (float)Math.Atan2((double)direction.Y, (double)direction.X);
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isMoving == true)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.MotionBlur);
                TextureLoader.MotionBlur.Parameters["Angle"].SetValue((float)Math.Atan2(Speed.Y, Speed.X));
                base.Draw(spriteBatch);
                spriteBatch.End();
                spriteBatch.Begin();
            } else
                base.Draw(spriteBatch);

        }




    }
}
