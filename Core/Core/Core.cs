using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Particles;
using Microsoft.Xna.Framework.Input;

namespace Core
{
    public class Core
    {
        Song Song;
        ParticleController particleController;
        public Core(Song song)
        {
            particleController = new ParticleController();
            Song = song;
            MediaPlayer.Play(Song);
            MediaPlayer.IsVisualizationEnabled = true;
            
            
        }

        public string Update(GameTime gameTime)
        {
            VisualizationData vd = new VisualizationData();
            MediaPlayer.GetVisualizationData(vd);
            for (int i = 0; i < 256; i++)
            {
                particleController.Beat(new Vector2(5 * i, 100), vd.Samples[i]);
                particleController.Beat(new Vector2(5 * i, 300), vd.Frequencies[i]);
            }
            particleController.Update(gameTime);
            return "OK";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            particleController.Draw(spriteBatch);
        }
    }
}
