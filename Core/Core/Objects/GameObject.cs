using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Core.Objects
{
    public class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public float MaxSpeed { get; set; }
        public Vector2 Acceleration { get; set; }
        public float Angle { get; set; }
        public bool Alive { get; set; }
        public string Tag { get; set; }
        TimeSpan UpdateTime;

        public GameObject() { }

        public GameObject(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            UpdateTime = new TimeSpan(0, 0, 0, 0, 50);
        }

        public virtual void Update(GameTime gameTime)
        {
            Speed += Acceleration;
            if (Speed.Length() > MaxSpeed)
            {
                Speed.Normalize();
                Speed *= MaxSpeed;
            }
            Position += Speed; 
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height), null, Color.White, Angle+(float)(Math.PI/2), new Vector2(Texture.Width/2, Texture.Height/2), SpriteEffects.None, 0);
        }

    }
}
