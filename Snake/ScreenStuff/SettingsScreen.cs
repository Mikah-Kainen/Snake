using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Snake.ScreenStuff
{
    public class SettingsScreen : Screen
    {
        public Dictionary<Direction, Keys> Directions { get; private set; }

        public SettingsScreen(GraphicsDeviceManager graphicsDeviceManager, ContentManager content, ScreenManager screenManager, Dictionary<Direction, Keys> directions)
            : base(graphicsDeviceManager, content, screenManager)
        {
            Directions = directions;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Draw(spriteBatch);
        }



        public override void Reset()
        {
            throw new NotImplementedException();
        }


    }
}
