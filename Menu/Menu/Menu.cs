using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menu.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Menu
{
    public class Menu
    {
        public StatesContainer States { get; set; }

        public Menu()
        {
            States = new StatesContainer();
        }

        public string Update(GameTime gameTime)
        {
            if (Return.Message == "") Return.Message = "OK";
            if(Return.Message != "OK")
                return Return.Message;

            States.Update(gameTime);

            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            States.Draw(spriteBatch);
        }
    }
}
