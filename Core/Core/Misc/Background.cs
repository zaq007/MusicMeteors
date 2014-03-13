using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GlobalHandlers.Mouse;

namespace Core.Misc
{
    static public class Background
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.Background, new Vector2(0, 0), Color.WhiteSmoke);
        }
    }
}
