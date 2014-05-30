using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Menu
{
    public static class TextureLoader
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        private static Texture2D btnNewGame;
        public static Texture2D BtnNewGame
        {
            get
            {
                if (btnNewGame == null)
                    btnNewGame = content.Load<Texture2D>("New Game");
                return btnNewGame;
            }
        }

        private static Texture2D btnExit;
        public static Texture2D BtnExit
        {
            get
            {
                if (btnExit == null)
                    btnExit = content.Load<Texture2D>("Exit");
                return btnExit;
            }
        }
        
    }
}
