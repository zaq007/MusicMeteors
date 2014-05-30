using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    class MeteorController : IController
    {
        public string Name { get { return "MeteorController"; } }

        public List<Meteor> Meteors
        {
            get
            {
                return ObjectContainer.Instance.GetElementsByTag("Meteor") as List<Meteor>;
            }
        }

        public void Update(Microsoft.Xna.Framework.GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderTarget2D render)
        {
            throw new NotImplementedException();
        }
    }
}
