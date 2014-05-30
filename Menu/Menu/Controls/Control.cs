using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GlobalHandlers.Mouse;

namespace Menu.Controls
{
    public abstract class Control
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Control()
        {
            MouseHandler.OnClick += this.OnClick;
        }

        ~Control()
        {
            MouseHandler.OnClick -= this.OnClick;
        }

        public abstract void OnClick(object sender, MouseAgrs e); 


        public abstract void Update(GameTime gameTime);


        public abstract void Draw(SpriteBatch spriteBatch, RenderTarget2D render);

    }
}
