using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    class PositionController : IController
    {
        string IController.Name
        {
            get { return "PositionController"; }
        }

        List<GameObject> Objects;

        public PositionController()
        {
            Objects = ObjectContainer.Instance.GetObjects();
        }

        void IController.Update(Microsoft.Xna.Framework.GameTime gametime)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Position.X > 5 * 256 + 100 || Objects[i].Position.Y > 2 * 256 + 60 || Objects[i].Position.X < -100 || Objects[i].Position.Y < -100)
                {
                    if (Objects[i].GetType() != typeof(Player))
                    {
                        Objects[i].Free = true;
                    }          

                }
            }
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderTarget2D render)
        {

        }
    }
}
