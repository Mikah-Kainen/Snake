using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    public abstract class Screen
    {
        protected ContentManager Content { get; private set; }
        protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        protected ScreenManager ScreenManager { get; private set; }

        public Screen(GraphicsDeviceManager graphicsDevice, ContentManager content, ScreenManager screenManager)
        {
            GraphicsDeviceManager = graphicsDevice;
            Content = content;
            ScreenManager = screenManager;

        }
        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

