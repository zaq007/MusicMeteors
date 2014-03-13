using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    static public class ObjectContainer
    {
        static List<GameObject> Objects;

        static ObjectContainer()
        {
            Objects = new List<GameObject>();
        }

        public static IEnumerable<GameObject> GetElementsByTag(string tag)
        {
            return Objects.Where(x => x.Tag == tag);
        }

        public static void Add(GameObject go)
        {
            Objects.Add(go);
        }

        public static void Insert(int index, GameObject go)
        {
            Objects.Insert(index, go);
        }

        public static void Remove(GameObject go)
        {
            Objects.Remove(go);
        }

        public static void Update(GameTime gameTime)
        {
            for (int i = 0; i < Objects.Count; i++)
                Objects[i].Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var a in Objects)
                a.Draw(spriteBatch);
        }

    }
}
