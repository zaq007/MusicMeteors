using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Core.Misc;
using Core.Controllers;
using System.Timers;
using Core.Patterns;

namespace Core.Particles
{
    class ParticleController : IController
    {
        public string Name { get; set; }

        public Pool<Particle> particles;

        private Random random;

        public ParticleController()
        {
            this.particles = new Pool<Particle>();
            //for (int i = 0; i < 1000; i++)
            //    particles.Add(new Particle());
            random = new Random();
            Name = "ParticleController";
        }

        public void Beat(Vector2 position, float b)
        {
            Vector2 velocity = new Vector2(0, -100 * b);
            float angle = 0;
            float angleVel = 0;
            Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 0.5f);
            float size = 1f;
            int ttl = 2;
            float sizeVel = 0;
            float alphaVel = .01f;


            GenerateNewParticle(TextureLoader.Particle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
        }


        public void EngineRocket(Vector2 position)
        {
            for (int a = 0; a < 210; a++)
            {
                Vector2 velocity = AngleToV2((float)(Math.PI * 2d * random.NextDouble()), (float)random.NextDouble());
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1f, 1f, 1f, 1f);
                float size = 1f;
                int ttl = 80;
                float sizeVel = 0;
                float alphaVel = 0;


                GenerateNewParticle(TextureLoader.Smoke, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }

            for (int a = 0; a < 206; a++)
            {
                Vector2 velocity = AngleToV2((float)(Math.PI * 2d * random.NextDouble()), (float)random.NextDouble());
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 0.5f);
                float size = 1f;
                int ttl = 160;
                float sizeVel = 0;
                float alphaVel = .01f;


                GenerateNewParticle(TextureLoader.Sparcle, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }

            for (int a = 0; a < 230; a++)
            {
                Vector2 velocity = Vector2.Zero;
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 1f);
                float size = 0.1f + 1.8f * (float)random.NextDouble();
                int ttl = 20;
                float sizeVel = -.05f;
                float alphaVel = .01f;


                GenerateNewParticle(TextureLoader.Smoke, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }
        }

        private Particle GenerateNewParticle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Vector4 color, float size, int ttl, float sizeVel, float alphaVel) // генерация новой частички
        {
            var particle = particles.TryGet(typeof(Particle));
            if (particle == null)
            {
                particle = new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl, sizeVel, alphaVel);
                particles.Add(particle);
            }
            else
            {
                particle.Texture = texture;
                particle.Position = position;
                particle.Velocity = velocity;
                particle.AngularVelocity = angularVelocity;
                particle.Angle = angle;
                particle.Color = color;
                particle.Size = size;
                particle.TTL = ttl;
                particle.SizeVel = sizeVel;
                particle.AlphaVel = alphaVel;
                particle.Free = false;
            }
            return particle;
        }

        public void Update(GameTime gameTime)
        {

            for (int particle = 0; particle < particles.Count; particle++)
            {
                if (particles[particle].Free)
                    continue;
                particles[particle].Update(gameTime);
                if (particles[particle].Size <= 0 || particles[particle].TTL <= 0)
                {
                    particles[particle].Free = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            /*spriteBatch.End();
            RenderTarget2D a = new RenderTarget2D(spriteBatch.GraphicsDevice, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            RenderTarget2D b = new RenderTarget2D(spriteBatch.GraphicsDevice, spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height, false, SurfaceFormat.Vector4, DepthFormat.None);
            
            spriteBatch.GraphicsDevice.SetRenderTarget(a);
            spriteBatch.Begin();
            Background.Draw(spriteBatch, a);*/
            for (int index = 0; index < particles.Count; index++)
            {
                if(!particles[index].Free)
                    particles[index].Draw(spriteBatch, render);
            }
            /*
            spriteBatch.End();
            
            spriteBatch.GraphicsDevice.SetRenderTarget(b);
            spriteBatch.Begin();
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch, b);
            }
            spriteBatch.End();

            spriteBatch.GraphicsDevice.SetRenderTarget(render);
            TextureLoader.Flex.Parameters["displacementMap"].SetValue(b);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.Flex);
            //spriteBatch.Begin();
            
            spriteBatch.Draw(a, Vector2.Zero, Color.White);
            spriteBatch.End();
            spriteBatch.Begin();*/
        }

        public Vector2 AngleToV2(float angle, float length)
        {
            Vector2 direction = Vector2.Zero;
            direction.X = (float)Math.Cos(angle) * length;
            direction.Y = -(float)Math.Sin(angle) * length;
            return direction;
        }

        public void Boom(Vector2 vector2)
        {
            vector2 = BoomParticles(vector2);
            Timer t = new Timer(200);
            t.Elapsed += delegate
            {
                BoomParticles(vector2);
                Timer a = new Timer(400);
                a.Elapsed += delegate
                {
                    BoomParticles(vector2);
                };
                a.AutoReset = false;
                a.Start();
            };
            t.AutoReset = false;
            t.Start();
        }

        private Vector2 BoomParticles(Vector2 vector2)
        {
            for (int a = 0; a < 360; a++)
            {
                Vector2 velocity = AngleToV2((float)((Math.PI * a) / 180), 0.5f + (float)random.NextDouble());
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 0.5f);
                float size = 1f;
                int ttl = 160;
                float sizeVel = 0;
                float alphaVel = .01f;


                GenerateNewParticle(TextureLoader.Sparcle, vector2, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
                velocity = AngleToV2((float)((Math.PI * a) / 180), 0.7f + (float)random.NextDouble() * 0.6f);
                GenerateNewParticle(TextureLoader.Sparcle, vector2, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }
            return vector2;
        }
    }
}
