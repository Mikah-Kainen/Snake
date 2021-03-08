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
        Rectangle _screen => GraphicsDeviceManager.GraphicsDevice.Viewport.Bounds;

        public GameScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content, ScreenManager screenManager)
            : base(graphics, content, screenManager)
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = xBound;
            GraphicsDeviceManager.PreferredBackBufferHeight = yBound;
            GraphicsDeviceManager.ApplyChanges();

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

            _snake = new Snake(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Red, new Vector2(50, 50), 100, directionDictionary, _screen);

            _food = new Food(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen);
        }

        public override void Update(GameTime gameTime)
        {
            _snake.Update(gameTime);
            if(didLose())
            {
                ScreenManager.SetScreen(Screens.Replay);
            }
            if (_snake.snakeParts[0].HitBox.Intersects(_food.HitBox))
            {
                _food = new Food(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen);
                _snake.AddPart();
            }

            _food.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
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

        private bool didLose()
        {
            if (_snake.snakeParts[0].X + _snake.partSize.X > _screen.Right || _snake.snakeParts[0].X < _screen.Left || _snake.snakeParts[0].Y + _snake.partSize.Y > _screen.Bottom || _snake.snakeParts[0].Y < _screen.Top)
            {
                return true;
            }
            for (int i = 1; i < _snake.snakeParts.Count; i++)
            {
                if (_snake.snakeParts[0].HitBox.Intersects(_snake.snakeParts[i].HitBox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
