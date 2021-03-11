using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    class ReplayScreen : Screen
    {
        private bool didDraw;

        public ReplayScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content, ScreenManager screenManager)
            : base(graphics, content, screenManager)
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = xBound;
            GraphicsDeviceManager.PreferredBackBufferHeight = yBound;
            GraphicsDeviceManager.ApplyChanges();

            didDraw = false;
        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            var input = ks.GetPressedKeys();
            foreach (Keys key in input)
            {
                if(key.Equals(Keys.Up))
                {
                    ScreenManager.ClearScreens();
                    ScreenManager.SetScreen(Screens.Game);
                    ScreenManager.CurrentScreen.Reset();
                }
            }

            didDraw = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!didDraw)
            {
                didDraw = true;
                ScreenManager.Draw(spriteBatch);
            }
        }

        public override void Reset()
        {
        }
    }
}
