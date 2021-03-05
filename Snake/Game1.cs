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
        private ScreenManager _screenManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
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

            _screenManager.AddScreen(Screens.Game, new GameScreen(_graphics, 1000, 800, Content, _screenManager));
            _screenManager.AddScreen(Screens.Test, new TestScreen(_graphics, 1000, 800, Content, _screenManager));
            _screenManager.AddScreen(Screens.Replay, new ReplayScreen(_graphics, 1000, 800, Content, _screenManager));

            _screenManager.SetScreen(Screens.Game);

            _screenManager.CurrentScreen.Load();

            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.DarkBlue, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.GreenYellow, new Vector2(25, 25), _screen));
            //_foods.Add(new Food(CreatePixel(GraphicsDevice), Color.PaleGoldenrod, new Vector2(25, 25), _screen));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _screenManager.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Clear
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            _screenManager.Draw(_spriteBatch);
            base.Draw(gameTime);
        }


    }
}
