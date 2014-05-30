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

        static Texture2D sparcle;
        public static Texture2D Sparcle
        {
            get
            {
                if (sparcle == null)
                    sparcle = content.Load<Texture2D>("Sparcle");
                return sparcle;
            }
        }

        static Texture2D meteor;
        public static Texture2D Meteor
        {
            get
            {
                if (meteor == null)
                    meteor = content.Load<Texture2D>("Meteor");
                return meteor;
            }
        }

        static Texture2D smoke;
        public static Texture2D Smoke
        {
            get
            {
                if (smoke == null)
                    smoke = content.Load<Texture2D>("Smoke");
                return smoke;
            }
        }

        static Texture2D player;
        public static Texture2D Player
        {
            get
            {
                if (player == null)
                    player = content.Load<Texture2D>("Player");
                return player;
            }
        }

        static Texture2D background;
        public static Texture2D Background
        {
            get
            {
                if (background == null)
                    background = content.Load<Texture2D>("background");
                return background;
            }
        }

        static Texture2D gameOver;
        public static Texture2D GameOver
        {
            get
            {
                if (gameOver == null)
                    gameOver = content.Load<Texture2D>("GameOver");
                return gameOver;
            }
        }

        static Effect std;
        public static Effect Std
        {
            get
            {
                if (std == null)
                    std = content.Load<Effect>("std");
                return std;
            }
        }

        static Effect flex;
        public static Effect Flex
        {
            get
            {
                if (flex == null)
                {
                    flex = content.Load<Effect>("Flex");

                }
                return flex;
            }
        }

        static Effect bloom;
        public static Effect Bloom
        {
            get
            {
                if (bloom == null)
                    bloom = content.Load<Effect>("Bloom");
                return bloom;
            }
        }

        static Effect glow;
        public static Effect Glow
        {
            get
            {
                if (glow == null)
                    glow = content.Load<Effect>("Glow");
                return glow;
            }
        }

        static Effect blur;
        public static Effect Blur
        {
            get
            {
                if (blur == null)
                    blur = content.Load<Effect>("Blur");
                return blur;
            }
        }

        static Effect mblur;
        public static Effect MotionBlur
        {
            get
            {
                if (mblur == null)
                    mblur = content.Load<Effect>("MotionBlur");
                return mblur;
            }
        }
    }
}
