using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GlobalHandlers.Keyboard
{
    public static class KeyboardHandler
    {
        static Keys[] Previous;

        public static event EventHandler<KeyboardEventArg> OnPress = delegate { };
        
        static KeyboardHandler()
        {
            Previous = Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys();
        }

        public static void Update(GameTime gameTime)
        {
            Keys[] Current = Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys();
            var pressed = new List<Keys>();
            var clicked = new List<Keys>();
            pressed = Current.Where(x => Previous.Contains(x)).ToList<Keys>();
            clicked = Current.Where(x => !Previous.Contains(x)).ToList<Keys>();
            if (pressed.Count != 0 || clicked.Count != 0)
                OnPress(null, new KeyboardEventArg(pressed, clicked));
            Previous = Current;
        }



    }
}
