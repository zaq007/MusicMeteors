using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Patterns;

namespace Core.Objects
{
    public class ObjectContainer : Pool<GameObject>
    {
        private static ObjectContainer instance;
        public static ObjectContainer Instance
        {
            get
            {
                if (instance == null)
                    instance = new ObjectContainer();
                return instance;
            }
        }


        List<GameObject> ForAdding;

        ObjectContainer()
            : base()
        {
            ForAdding = new List<GameObject>();
        }


        public new void Add(GameObject a)
        {
            ForAdding.Add(a);
            return;
        }

        public List<GameObject> GetObjects()
        {
            return this;
        }

        public IEnumerable<GameObject> GetElementsByTag(string tag)
        {
            return this.Where(x => x.Tag == tag);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Free)
                    continue;
                this[i].Update(gameTime);
            }
            for (var a = 0; a < ForAdding.Count; a++ )
            {
                base.Add(ForAdding[a]);
            }
            ForAdding.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            foreach (var a in this)
                a.Draw(spriteBatch, render);
        }

        internal void Dispose()
        {
            instance = null;
        }
    }
}
