using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Snake _snake;

        Rectangle _screen => GraphicsDevice.Viewport.Bounds;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _snake = new Snake(CreatePixel(GraphicsDevice), Color.Red, new Vector2(50, 50), 1000);
            _snake.AddPart();
            _snake.AddPart();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_snake.length < 4)
            {
                _snake.AddPart();
            }
            _snake.Update(gameTime, _screen);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _snake.Draw(_spriteBatch);

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
