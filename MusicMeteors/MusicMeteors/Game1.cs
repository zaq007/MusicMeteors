using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Reflection;
using System.Diagnostics;
using GlobalHandlers.Mouse;
using GlobalHandlers.Keyboard;
using Core.Misc;

namespace MusicMeteors
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu.Menu menu;
        Core.Core core;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 5 * 256;
            graphics.PreferMultiSampling = true;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Menu.TextureLoader.Initialize(this.Content);
            Core.Misc.TextureLoader.Initialize(this.Content);
            //Song song = new Song(new Uri("file:///C:/Kenny Chesney - Me and You.mp3"));
            //var ctor = typeof(Song).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(string), typeof(int) }, null);
            //Song song = (Song)ctor.Invoke(new object[] { "name", @"C:/Kenny Chesney - Me and You.mp3", 0 });
            //MediaPlayer.Play(song);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (core != null)
                    core.Dispose();
                core = null;
                Menu.Return.Message = "OK";
                GameState.setState("Menu");
            }
            MouseHandler.Update(gameTime);
            KeyboardHandler.Update(gameTime);
            if (GameState.getState() == "Menu")
            {
                if (menu == null)
                {
                    menu = new Menu.Menu();
                }
                else
                {                    
                    var msg = menu.Update(gameTime);
                    switch (msg)
                    {
                        case "OK": break;
                        case "Exit": Exit(); break;
                        default:
                            var ctor = typeof(Song).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string), typeof(string), typeof(int) }, null);
                            Song song = (Song)ctor.Invoke(new object[] { "name", msg, 0 });
                            core = new Core.Core(song);
                            menu = null;
                            GameState.setState("Game");
                            break;
                    }
                }
            }
            else
            {
                if (core != null)
                {
                    var msg = core.Update(gameTime);
                    switch (msg)
                    {
                        case "DEAD": break;
                        default: break;
                    }
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            RenderTarget2D render = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            RenderTarget2D render1 = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            GraphicsDevice.SetRenderTarget(render);
            
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.Std);
            
            spriteBatch.Begin();
            switch (GameState.getState())
            {
                case "Menu": menu.Draw(spriteBatch, render); break;
                case "Game": core.Draw(spriteBatch, render); break;
            }            
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(render1);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.Std);
            spriteBatch.Draw(render, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            TextureLoader.Bloom.Parameters[0].SetValue(render1);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, TextureLoader.Bloom);
            spriteBatch.Draw(render1, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            render.Dispose();
            render1.Dispose();
            base.Draw(gameTime);
        }
    }
}
