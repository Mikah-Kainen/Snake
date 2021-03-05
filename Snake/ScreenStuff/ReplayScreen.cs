using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    class ReplayScreen : Screen
    {
        public ReplayScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content, ScreenManager screenManager)
            : base(graphics, content, screenManager)
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = xBound;
            GraphicsDeviceManager.PreferredBackBufferHeight = yBound;
            GraphicsDeviceManager.ApplyChanges();
        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
