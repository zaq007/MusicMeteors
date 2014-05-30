using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Core.Misc;
using Core.Particles;
using Microsoft.Xna.Framework;
using Core.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    class MusicController : IController
    {
        public const float BEAT_COST = .4f; 
        public const float ACCUMULATE_SPEED = .001f;
        public const float BEAT_REACTION = .7f; 
        public const float ACCOMULATOR_REACTION = .8f;

        public string Name { get; set; }
        public List<float> accomulator { get; set; }

        public MusicController()
        {
            Name = "MusicController";
            MediaPlayer.Play(Core.Song);
            MediaPlayer.IsVisualizationEnabled = true;
            accomulator = new List<float>(); 
            for (int a = 0; a < 128; a++)
            {
                accomulator.Add(1.0f);
            }
        }

        public void Update(Microsoft.Xna.Framework.GameTime gametime)
        {
            VisualizationData vd = new VisualizationData();
            MediaPlayer.GetVisualizationData(vd);
            TextureLoader.Std.Parameters[0].SetValue(((vd.Samples.Average() < 0) ? 0 : vd.Samples.Average()) + vd.Samples.Max());
            /*for (int i = 0; i < 256; i++)
            {
                (MainController.Instance.GetByName("ParticleController") as ParticleController).Beat(new Vector2(5 * i, 100), vd.Samples[i]);
                (MainController.Instance.GetByName("ParticleController") as ParticleController).Beat(new Vector2(5 * i, 300), vd.Frequencies[i]);
            }*/
            for (int a = 52; a < 180; a++)
            {
                if (vd.Frequencies[a] > BEAT_REACTION && accomulator[a - 52] > ACCOMULATOR_REACTION)
                {
                    var meteor = ObjectContainer.Instance.TryGet(typeof(Meteor)) as Meteor;
                    if (meteor == null)
                    {
                        ObjectContainer.Instance.Add(new Meteor());
                    }
                    else
                    {
                        meteor.Reuse();
                    }
                    accomulator[a - 52] -= BEAT_COST; // убавляем аккумулятор
                }
            }
            for (int a = 52; a < 180; a++)
                if (accomulator[a-52] < 1.0f)
                    accomulator[a-52] += ACCUMULATE_SPEED;
        }

        public float GetSpeedForMeteor()
        {
            VisualizationData vd = new VisualizationData();
            MediaPlayer.GetVisualizationData(vd);
            return vd.Samples.Max() * 3;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderTarget2D render)
        {
            
        }
    }
}
