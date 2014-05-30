using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menu.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Menu.States
{
    public abstract class State
    {
        public List<Control> Controls { get; set; }

        public State()
        {
            Controls = new List<Control>();
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, RenderTarget2D render);
    }
}
