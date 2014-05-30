using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    class ColisionController : IController
    {
        public event EventHandler<ColisionArgs> OnColision = delegate { };

        public string Name { get { return "ColisionController"; } }

        public List<GameObject> Entities { get { return ObjectContainer.Instance.GetObjects(); } }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach(var a in Entities)
                foreach(var b in Entities)
                    if(a != b && a.Free == false && b.Free == false)
                        if(a.GetType() != b.GetType())
                            if (new Rectangle((int)a.Position.X - a.Texture.Width / 2, (int)a.Position.Y - a.Texture.Height / 2, a.Texture.Width, a.Texture.Height).Intersects(new Rectangle((int)b.Position.X - b.Texture.Width / 2, (int)b.Position.Y - b.Texture.Height / 2, b.Texture.Width, b.Texture.Height)))
                                OnColision(b, new ColisionArgs(a));
        }
        
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderTarget2D render)
        {

        }
    }
}
