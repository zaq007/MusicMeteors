using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalHandlers.Keyboard
{
    public class KeyboardEventArg : EventArgs
    {
        public List<Microsoft.Xna.Framework.Input.Keys> pressed { get; set; }
        public List<Microsoft.Xna.Framework.Input.Keys> clicked { get; set; }

        public KeyboardEventArg(List<Microsoft.Xna.Framework.Input.Keys> pressed, List<Microsoft.Xna.Framework.Input.Keys> clicked)
        {
            this.pressed = pressed;
            this.clicked = clicked;
        }
    }
}
