using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    public class SettingsScreen : Screen
    {

        public SettingsScreen(GraphicsDeviceManager graphicsDeviceManager, ContentManager content, ScreenManager screenManager)
            : base(graphicsDeviceManager, content, screenManager)
        {
        }

        public override void Load()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Draw(spriteBatch);
        }



        public override void Reset()
        {
            throw new NotImplementedException();
        }


    }
}
