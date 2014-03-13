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
            ObjectContainer.Add(new Player());
        }

        public string Update(GameTime gameTime)
        {
            VisualizationData vd = new VisualizationData();
            MediaPlayer.GetVisualizationData(vd);
            TextureLoader.Std.Parameters[0].SetValue(((vd.Samples.Average()<0)?0:vd.Samples.Average())+vd.Samples.Max());
            for (int i = 0; i < 256; i++)
            {
                particleController.Beat(new Vector2(5 * i, 100), vd.Samples[i]);
                particleController.Beat(new Vector2(5 * i, 300), vd.Frequencies[i]);
            }
            particleController.Update(gameTime);
            ObjectContainer.Update(gameTime);
            return "OK";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            ObjectContainer.Draw(spriteBatch);
            particleController.Draw(spriteBatch);
        }
    }
}
