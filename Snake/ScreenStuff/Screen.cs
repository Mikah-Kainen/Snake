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
        protected GraphicsDeviceManager GraphicsDevice { get; private set; }

        public Screen(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            GraphicsDevice = graphicsDevice;
            Content = content;
        }
        public abstract void Load();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

