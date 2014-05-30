using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Misc;
using Microsoft.Xna.Framework;
using System.Timers;
using Core.Controllers;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    public class Meteor : GameObject
    {
        public Meteor(Vector2 position) : base(TextureLoader.Meteor, position) 
        {
            MaxSpeed = 2f;
            Speed = new Vector2(1, 1);
            Tag = "Meteor";
            Timer timer = new Timer(0.16);
            timer.Elapsed += delegate { Angle += (float)Math.PI / 170; };
            timer.AutoReset = true;
            timer.Start();
        }

        public Meteor()
            : base(TextureLoader.Meteor, Vector2.Zero)
        {
            MaxSpeed = (MainController.Instance.GetByName("MusicController") as MusicController).GetSpeedForMeteor() * 6;
            Random r = new Random();
            Vector2 Position = new Vector2(r.Next(-100, 5 * 256 + 100), r.Next(-100, 2 * 256 + 60));
            if ((Position.X > -20 && Position.X < 5*256 + 30) || (Position.Y > -20 && Position.Y < 2*256))
            {
                if (Position.X > -20 && Position.X < 5 * 256 / 2)
                {
                    Position.X = -20;
                    Speed = new Vector2(1, 0);
                } else
                if (Position.Y > -20 && Position.Y < 2 * 256 - 30 / 2)
                {
                    Position.Y = -20;
                    Speed = new Vector2(0, 1);
                } else
                if (Position.X < 2*256+30 && Position.X > 5 * 256 / 2)
                {
                    Position.X = 2*256+3;
                    Speed = new Vector2(-1, 0);
                } else
                if (Position.Y < 2*256 && Position.Y > 2 * 256 - 30 / 2)
                {
                    Position.Y = 2*256;
                    Speed = new Vector2(0, -1);
                }
            }
            Speed *= (MainController.Instance.GetByName("MusicController") as MusicController).GetSpeedForMeteor() * 3;
            this.Position = Position;
            Tag = "Meteor";
            Timer timer = new Timer(0.16);
            timer.Elapsed += delegate { Angle += (float)Math.PI / 150; };
            timer.AutoReset = true;
            timer.Start();
        }



        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            /*Random r = new Random();
            Vector2 NextSpeed = new Vector2((float)r.NextDouble(), (float)r.NextDouble());
            NextSpeed.Normalize();
            if (Speed.X < 0 && NextSpeed.X < -0.5 && Position.X < 5 * 256 / 2)
                NextSpeed.X += 0.5F;
            if (Speed.Y < 0 && NextSpeed.Y < -0.5 && Position.Y < 3*256/2)
                NextSpeed.Y += 0.5F;
            if (Speed.Y > 0 && NextSpeed.Y > 0.5 && Position.Y > 3 * 256 / 2)
                NextSpeed.Y -= 0.5F;
            if (Speed.X > 0 && NextSpeed.X > 0.5 && Position.X > 5 * 256 / 2)
                NextSpeed.X -= 0.5F;
            NextSpeed.Normalize();
            Speed = NextSpeed * MaxSpeed;*/
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderTarget2D render)
        {
                base.Draw(spriteBatch, render);
        }

        public void Reuse()
        {
            MaxSpeed = (MainController.Instance.GetByName("MusicController") as MusicController).GetSpeedForMeteor() * 6;
            Random r = new Random();
            Vector2 Position = new Vector2(r.Next(-100, 5 * 256 + 100), r.Next(-100, 2 * 256 + 60));
            if ((Position.X > -20 && Position.X < 5 * 256 + 30) || (Position.Y > -20 && Position.Y < 2 * 256))
            {
                if (Position.X > -20 && Position.X < 5 * 256 / 2)
                {
                    Position.X = -20;
                    Speed = new Vector2(1, 0);
                }
                else
                    if (Position.Y > -20 && Position.Y < 2 * 256 - 30 / 2)
                    {
                        Position.Y = -20;
                        Speed = new Vector2(0, 1);
                    }
                    else
                        if (Position.X < 2 * 256 + 30 && Position.X > 5 * 256 / 2)
                        {
                            Position.X = 2 * 256 + 3;
                            Speed = new Vector2(-1, 0);
                        }
                        else
                            if (Position.Y < 2 * 256 && Position.Y > 2 * 256 - 30 / 2)
                            {
                                Position.Y = 2 * 256;
                                Speed = new Vector2(0, -1);
                            }
            }
            Speed *= (MainController.Instance.GetByName("MusicController") as MusicController).GetSpeedForMeteor() * 3;
            this.Position = Position;
            Free = false;
        }


    }
}
