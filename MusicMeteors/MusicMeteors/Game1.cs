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
                core = null;
                GC.Collect();
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
                    core.Update(gameTime);
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
            spriteBatch.Begin();
            switch (GameState.getState())
            {
                case "Menu": menu.Draw(spriteBatch); break;
                case "Game": core.Draw(spriteBatch); break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
