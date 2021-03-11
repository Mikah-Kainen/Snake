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

        MyStack<Screen> previousScreens;

        Dictionary<Screens, Screen> screenMap;

        public Settings Setting { get; private set; }

        public ScreenManager(Settings setting)
        {
            CurrentScreen = null;
            previousScreens = new MyStack<Screen>();
            screenMap = new Dictionary<Screens, Screen>();
            Setting = setting;
        }

        public bool SetScreen(Screens nextScreen)
        {
            if(!screenMap.ContainsKey(nextScreen))
            {
                throw new Exception("Does not comtain screen");
            }
            if (CurrentScreen != null)
            {
                previousScreens.Push(CurrentScreen);
            }
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

        public void ClearScreens()
        {
            previousScreens.Clear();
        }

        public void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Screen screen in previousScreens)
            {
                screen.Draw(spriteBatch);
            }
            CurrentScreen.Draw(spriteBatch);
        }

        //Update function

        //Draw function


    }
}
