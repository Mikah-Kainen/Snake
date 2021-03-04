using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Food _food;
        Snake _snake;
        private bool _endGame;
        Rectangle _screen => GraphicsDevice.Viewport.Bounds;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _endGame = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Dictionary<Keys, Direction> directionDictionary = new Dictionary<Keys, Direction>()
            {
                [Keys.Up] = Direction.Up,
                [Keys.Left] = Direction.Left,
                [Keys.Down] = Direction.Down,
                [Keys.Right] = Direction.Right,
            };

            _snake = new Snake(CreatePixel(GraphicsDevice), Color.Red, new Vector2(50, 50), 300, directionDictionary);

            _food = new Food(CreatePixel(GraphicsDevice), Color.Black, new Vector2(25,25), _screen);
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.DarkBlue, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.GreenYellow, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.PaleGoldenrod, new Vector2(25, 25), _screen));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || _endGame)
                Exit();

            _endGame = _snake.Update(gameTime, _screen);
            if(_snake.snakeParts[0].HitBox.Intersects(_food.HitBox))
            {
                _food = new Food(CreatePixel(GraphicsDevice), Color.Black, new Vector2(25, 25), _screen);
                _snake.AddPart();
            }

            _food.Update();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _snake.Draw(_spriteBatch);
            _food.Draw(_spriteBatch);

            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private Texture2D CreatePixel(GraphicsDevice device)
        {
            Texture2D texture = new Texture2D(device, 1, 1);

            texture.SetData(new Color[] { Color.White });

            return texture;
        }
    }
}
