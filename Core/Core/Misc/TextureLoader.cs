using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Core.Misc
{
    public static class TextureLoader
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        static Texture2D particle;
        public static Texture2D Particle
        {
            get
            {
                if (particle == null)
                    particle = content.Load<Texture2D>("Particle");
                return particle;
            }
        }       

    }
}
