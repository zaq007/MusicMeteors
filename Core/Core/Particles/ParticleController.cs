using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Core.Misc;

namespace Core.Particles
{
    class ParticleController
    {

        public List<Particle> particles;

        private Random random;

        public ParticleController()
        {
            this.particles = new List<Particle>();
            random = new Random();
        }

        public void Beat(Vector2 position, float b)
        {
            Vector2 velocity = new Vector2(0, -100*b);
            float angle = 0;
            float angleVel = 0;
            Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 0.5f);
            float size = 1f;
            int ttl = 2;
            float sizeVel = 0;
            float alphaVel = .01f;


            GenerateNewParticle(TextureLoader.Particle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
        }


        public void EngineRocket(Vector2 position) // функция, которая будет генерировать частицы
        {
            for (int a = 0; a < 2; a++) // создаем 2 частицы дыма для трейла
            {
                Vector2 velocity = AngleToV2((float)(Math.PI * 2d * random.NextDouble()), 0.6f);
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1f, 1f, 1f, 1f);
                float size = 1f;
                int ttl = 40;
                float sizeVel = 0;
                float alphaVel = 0;


                GenerateNewParticle(TextureLoader.Particle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }

            for (int a = 0; a < 1; a++) // создаем 1 искру для трейла
            {
                Vector2 velocity = AngleToV2((float)(Math.PI * 2d * random.NextDouble()), .2f);
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 0.5f);
                float size = 1f;
                int ttl = 80;
                float sizeVel = 0;
                float alphaVel = .01f;


                GenerateNewParticle(TextureLoader.Particle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }

            for (int a = 0; a < 10; a++) // создаем 10 дыма, но на практике — реактивная струя для трейла
            {
                Vector2 velocity = Vector2.Zero;
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 1f);
                float size = 0.1f + 1.8f * (float)random.NextDouble();
                int ttl = 10;
                float sizeVel = -.05f;
                float alphaVel = .01f;


                GenerateNewParticle(TextureLoader.Particle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }
        }

        private Particle GenerateNewParticle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Vector4 color, float size, int ttl, float sizeVel, float alphaVel) // генерация новой частички
        {
            Particle particle = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl, sizeVel, alphaVel);
            particles.Add(particle);
            return particle;
        }

        public void Update(GameTime gameTime)
        {

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update(gameTime);
                if (particles[particle].Size <= 0 || particles[particle].TTL <= 0) // если время жизни частички или её размеры равны нулю, удаляем её
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int index = 0; index < particles.Count; index++) // рисуем все частицы
            {
                particles[index].Draw(spriteBatch);
            }

        }

        public Vector2 AngleToV2(float angle, float length)
        {
            Vector2 direction = Vector2.Zero;
            direction.X = (float)Math.Cos(angle) * length;
            direction.Y = -(float)Math.Sin(angle) * length;
            return direction;
        }
    }
}
