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
        public Food(Texture2D tex, Color tint, Vector2 size, Rectangle bounds, Vector2 snakeSize)
        {
            gen = new Random();
            _tex = tex;
            _tint = tint;
            _size = size;

            int xParts = (int)(bounds.Right / snakeSize.X);
            int yParts = (int)(bounds.Bottom / snakeSize.Y);

            _pos.X = (int)snakeSize.X * gen.Next(0, xParts);
            _pos.X += (int)snakeSize.X / 2;
            _pos.Y = (int)snakeSize.Y * gen.Next(0, yParts);
            _pos.Y += (int)snakeSize.Y / 2;
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
