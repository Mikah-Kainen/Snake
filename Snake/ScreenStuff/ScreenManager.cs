using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.ScreenStuff
{
    public class ScreenManager
    {
        public Screen CurrentScreen { get; private set; }

        Stack<Screen> previousScreens;

        Dictionary<Screens, Screen> screenMap;

        public ScreenManager()
        {
            CurrentScreen = null;
            previousScreens = new Stack<Screen>();
            screenMap = new Dictionary<Screens, Screen>();

        }

        public bool SetScreen(Screens nextScreen)
        {
            if(!screenMap.ContainsKey(nextScreen))
            {
                return false;
            }
            previousScreens.Push(CurrentScreen);
            CurrentScreen = screenMap[nextScreen];
            return true;
        }

        public void AddScreen(Screens name, Screen screen)
        {
            screenMap.Add(name, screen);
        }

        public void LeaveScreen()
        {
            CurrentScreen = previousScreens.Pop();
        }

        public void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentScreen.Draw(spriteBatch);
        }

        //Update function

        //Draw function


    }
}
