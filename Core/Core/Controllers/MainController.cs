using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Particles;

namespace Core.Controllers
{
    public class MainController
    {
        private static MainController instance;
        public static MainController Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainController();
                return instance;
            }
        }

        public List<IController> Controllers { get; set; }

        
        private MainController()
        {
            Controllers = new List<IController>();
            Controllers.Add(new MusicController());
            Controllers.Add(new ParticleController());
            Controllers.Add(new ColisionController());
            Controllers.Add(new PositionController());
        }


        public void Update(GameTime gameTime)
        {
            foreach (var c in Controllers)
                c.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            foreach (var c in Controllers)
                c.Draw(spriteBatch, render);
        }

        public IController GetByName(string Name)
        {
            return Controllers.Where(x => string.Compare(x.Name, Name) == 0).ToArray()[0];
        }

        internal void Dispose()
        {
            instance = null;
        }
    }
}
