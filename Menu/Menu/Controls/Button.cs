using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GlobalHandlers.Mouse;

namespace Menu.Controls
{
    public class Button : Control
    {
        public delegate void Click(object sender, MouseAgrs e);

        Click Action;

        public Button(Texture2D texture, Vector2 position, Click click)
        {
            Position = position;
            Texture = texture;
            Action = click;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public override void OnClick(object sender, MouseAgrs e)
        {
            if (new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height).Contains((int)e.Position.X, (int)e.Position.Y))
                Action(sender, e);
        }
    }
}
