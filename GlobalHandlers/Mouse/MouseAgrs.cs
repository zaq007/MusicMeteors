using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GlobalHandlers.Mouse
{
    public class MouseAgrs : EventArgs
    {
        public Key ClickedKey { get; set; }
        public Vector2 Position { get; set; }

        public MouseAgrs(Key key)
        {
            ClickedKey = key;
            Position = new Vector2(Microsoft.Xna.Framework.Input.Mouse.GetState().X, Microsoft.Xna.Framework.Input.Mouse.GetState().Y);
        }
    }
}
