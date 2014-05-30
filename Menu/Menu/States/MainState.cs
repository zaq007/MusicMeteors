using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Menu.Controls;
using System.Windows.Forms;
using GlobalHandlers.Mouse;

namespace Menu.States
{
    public class MainState : State
    {
        public MainState()
        {
            Controls.Add(new Controls.Button(TextureLoader.BtnNewGame, new Vector2(5*256/2-200, 100), delegate
                {
                   OpenFileDialog dialog = new OpenFileDialog();
                   dialog.Filter = "(*.mp3)|*.mp3|(*.wav)|*.wav";
                   dialog.ShowDialog();
                   Return.Message = dialog.FileName;
                   MouseHandler.OnClick -= Controls[0].OnClick;
                   dialog.Dispose();
                }));

            Controls.Add(new Controls.Button(TextureLoader.BtnExit, new Vector2(5 * 256 / 2 - 120, 200), delegate
                {
                    Return.Message = "Exit";
                }));

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch, RenderTarget2D render)
        {
            foreach (var control in Controls)
                control.Draw(spriteBatch, render);
        }

    }
}
