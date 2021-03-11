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

        List<Keys> pressedKeys;
        public GameScreen(GraphicsDeviceManager graphics, int xBound, int yBound, ContentManager content, ScreenManager screenManager)
            : base(graphics, content, screenManager)
        {
            GraphicsDeviceManager.PreferredBackBufferWidth = xBound;
            GraphicsDeviceManager.PreferredBackBufferHeight = yBound;
            GraphicsDeviceManager.ApplyChanges();
        }

        public override void Load()
        {
            pressedKeys = new List<Keys>();

            _snake = new Snake(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Red, new Vector2(50, 50), 100, ScreenManager.Setting.DirectionDictionary, _screen);

            _food = new Food(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen, _snake.PartSize);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            var input = ks.GetPressedKeys();
            foreach(Keys key in input)
            {
                if(!pressedKeys.Contains(key) && !_snake.pressedKeys.Contains(key))
                {
                    pressedKeys.Add(key);
                }
            }
            while(pressedKeys.Count > 0)
            {
                if (ScreenManager.Setting.DirectionDictionary.ContainsKey(pressedKeys[0]))
                {
                    _snake.pressedKeys.Enqueue(pressedKeys[0]);
                }
                else if (ScreenManager.Setting.CommandDictionary.ContainsKey(pressedKeys[0]))
                {
                    ScreenManager.SetScreen(ScreenManager.Setting.CommandDictionary[pressedKeys[0]]);
                }
                pressedKeys.Remove(pressedKeys[0]);
            }
            _snake.Update(gameTime);
            if(didLose())
            {
                ScreenManager.SetScreen(Screens.Replay);
            }
            else if (_snake.snakeParts[0].HitBox.Intersects(_food.HitBox))
            {
                _food = new Food(CreatePixel(GraphicsDeviceManager.GraphicsDevice), Color.Black, new Vector2(25, 25), _screen, _snake.PartSize);
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
            if (_snake.snakeParts[0].X + _snake.PartSize.X > _screen.Right || _snake.snakeParts[0].X < _screen.Left || _snake.snakeParts[0].Y + _snake.PartSize.Y > _screen.Bottom || _snake.snakeParts[0].Y < _screen.Top)
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

        public override void Reset()
        {
            Load();
        }
    }
}
