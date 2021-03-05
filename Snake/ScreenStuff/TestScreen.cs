using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    class TestScreen : Screen
    {
        Food food;
        Rectangle screen => GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds;

        public TestScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content, ScreenManager screenManager)
            : base(graphics, content, screenManager)
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = xBound;
            GraphicsDeviceManager.PreferredBackBufferHeight = yBound;
            GraphicsDeviceManager.ApplyChanges();
        }

        public override void Load()
        {
            food = new Food(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Black, new Vector2(25,25), screen, new Vector2(500, 400));
        }

        public override void Update(GameTime gameTime)
        {
            food.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            food.Draw(spriteBatch);

            spriteBatch.End();
        }

        private Texture2D CreatePixel(GraphicsDevice device)
        {
            Texture2D texture = new Texture2D(device, 1, 1);

            texture.SetData(new Color[] { Color.White });

            return texture;
        }
    }
}
