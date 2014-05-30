using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Particles;
using Microsoft.Xna.Framework.Input;
using Core.Misc;
using Core.Objects;
using Core.Controllers;

namespace Core
{
    public class Core
    {
        static public Song Song;

        public Core(Song song)
        {
            Song = song;
            ObjectContainer.Instance.Add(new Player());
            //ObjectContainer.Instance.Add(new Meteor(new Vector2(100, 100)));
        }

        public string Update(GameTime gameTime)
        {
            Return.Message = "OK";
            MainController.Instance.Update(gameTime);
            ObjectContainer.Instance.Update(gameTime);
            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            Background.Draw(spriteBatch, render);
            MainController.Instance.Draw(spriteBatch, render);
            ObjectContainer.Instance.Draw(spriteBatch, render);
        }

        public void Dispose()
        {
            MainController.Instance.Dispose();
            ObjectContainer.Instance.Dispose();
        }
    }
}
