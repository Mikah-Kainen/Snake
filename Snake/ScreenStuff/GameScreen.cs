using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    class GameScreen : Screen
    {
        private Food _food;
        Snake _snake;
        Rectangle _screen => GraphicsDevice.GraphicsDevice.Viewport.Bounds;

        public GameScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content)
            : base(graphics, content)
        {
            GraphicsDevice.PreferredBackBufferWidth = xBound;
            GraphicsDevice.PreferredBackBufferHeight = yBound;
            GraphicsDevice.ApplyChanges();

        }

        public override void Load()
        {
            Dictionary<Keys, Direction> directionDictionary = new Dictionary<Keys, Direction>()
            {
                [Keys.Up] = Direction.Up,
                [Keys.Left] = Direction.Left,
                [Keys.Down] = Direction.Down,
                [Keys.Right] = Direction.Right,
            };

            _snake = new Snake(CreatePixel(GraphicsDevice.GraphicsDevice), Color.Red, new Vector2(50, 50), 300, directionDictionary);

            _food = new Food(CreatePixel(GraphicsDevice.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen);
        }

        public override void Update(GameTime gameTime)
        {
            _snake.Update(gameTime, _screen);
            if (_snake.snakeParts[0].HitBox.Intersects(_food.HitBox))
            {
                _food = new Food(CreatePixel(GraphicsDevice.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen);
                _snake.AddPart();
            }

            _food.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            _snake.Draw(spriteBatch);
            _food.Draw(spriteBatch);

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
