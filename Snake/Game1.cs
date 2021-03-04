using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.ScreenStuff;

using System.Collections.Generic;

namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Dictionary<Screens, Screen> _screenManager;
        Screens _currentScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

            _screenManager = new Dictionary<Screens, Screen>();
            _screenManager.Add(Screens.Game, new GameScreen(_graphics, 1000, 800, Content));
            _screenManager.Add(Screens.Test, new TestScreen(_graphics, 1000, 800, Content));


            _currentScreen = Screens.Test;

            _screenManager[_currentScreen].Load();

            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.DarkBlue, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.GreenYellow, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.PaleGoldenrod, new Vector2(25, 25), _screen));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _screenManager[_currentScreen].Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _screenManager[_currentScreen].Draw(_spriteBatch);
            base.Draw(gameTime);
        }


    }
}
