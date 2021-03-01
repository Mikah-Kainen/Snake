using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food
    {
        Texture2D _tex;
        Color _tint;
        float _rotation = 3;
        Vector2 _pos;
        Vector2 _size;
        public Rectangle HitBox => new Rectangle((int)_pos.X, (int)_pos.Y, (int)_size.X, (int)_size.Y);

        Random gen;
        public Food(Texture2D tex, Color tint, Vector2 size, Rectangle screen)
        {
            gen = new Random();
            _tex = tex;
            _tint = tint;
            _size = size;

            int xParts = (int)(screen.Right / size.X);
            int yParts = (int)(screen.Bottom / size.Y);

            //_pos.X = size.X * gen.Next(0, xParts);
            //_pos.Y = size.Y * gen.Next(0, yParts);

            _pos.X = 500;
            _pos.Y = 200;
        }
        public void Update()
        {
            _rotation -= (float)0.1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_tex, HitBox, );
            spriteBatch.MikahDraw(_tex, HitBox, _tint, _rotation);
        }

    }
}
