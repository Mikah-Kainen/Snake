using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        Texture2D _tex;
        Color _tint;
        Vector2 _headPos;
        Vector2 _partSize;
        int _length;
        List<Vector2> _snakeParts;
        
        public Snake(Texture2D tex, Color tint, Vector2 partSize)
        {
            _tex = tex;
            _tint = tint;
            _headPos = new Vector2(0, 0);
            _partSize = partSize;
        }

        public void Update(GameTime gameTime, Rectangle screen)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up))
            {
                _headPos.Y -= _partSize.Y;
            }
            else if(ks.IsKeyDown(Keys.Down))
            {
                _headPos.Y += _partSize.Y;
            }
            else if(ks.IsKeyDown(Keys.Right))
            {
                _headPos.X += _partSize.X;
            }
            else if(ks.IsKeyDown(Keys.Left))
            {
                _headPos.X -= _partSize.X;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_tex);
        }
    }
}
