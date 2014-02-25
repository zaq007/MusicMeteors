using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalHandlers.Mouse
{
    public static class MouseHandler
    {
        static MouseState previous;

        public static event EventHandler<MouseAgrs> OnClick = delegate { };

        static MouseHandler()
        {
            previous = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        public static void Update(GameTime gameTime)
        {
            var state = Microsoft.Xna.Framework.Input.Mouse.GetState();
            if (state.LeftButton == ButtonState.Released &&
                previous.LeftButton == ButtonState.Pressed)
                    OnClick(null, new MouseAgrs(Key.Left));
            if (state.RightButton == ButtonState.Released &&
                previous.RightButton == ButtonState.Pressed)
                    OnClick(null, new MouseAgrs(Key.Right));
            previous = state;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            
        }

    }
}
