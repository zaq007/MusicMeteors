using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Misc;
using Core.Controllers;

namespace Core.Objects
{
    class Bullet : GameObject
    {

        public Bullet(Vector2 position, Vector2 direction)
            : base(TextureLoader.Particle, position)
        {
            direction.Normalize();
            this.Speed = direction*6;
            MaxSpeed = 1;
            this.Tag = "Bullet";
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            base.Draw(spriteBatch, render);
        }

        public override void OnColision(object sender, Controllers.ColisionArgs e)
        {
            if (e.fhhgf == this)
            {
                if (sender.GetType() == typeof(Meteor))
                {
                    this.Free = true;
                    (sender as GameObject).Free = true;
                    (MainController.Instance.GetByName("ParticleController") as Particles.ParticleController).EngineRocket(this.Position);
                }
            }
        }

    }
}
