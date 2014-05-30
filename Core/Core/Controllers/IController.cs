using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    public interface IController
    {
        string Name { get; }

        void Update(GameTime gametime);

        void Draw(SpriteBatch spriteBatch, RenderTarget2D render);

    }
}
