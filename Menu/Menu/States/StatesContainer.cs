using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Menu.States
{
    public class StatesContainer
    {
        public List<State> States { get; set; }
        public int Current { get; set; }


        public StatesContainer()
        {
            States = new List<State>();
            States.Add(new MainState());
            Current = 0;
        }

        public void Update(GameTime gameTime)
        {
            States[Current].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            States[Current].Draw(spriteBatch);
        }

    }
}
