using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class SnakePart
    {
        public Vector2 _loc;
        public float X => _loc.X;
        public float Y => _loc.Y;
        public SnakePart(Vector2 loc)
        {
            _loc = loc;
        }

        public SnakePart(int x, int y)
        {
            _loc = new Vector2(x, y);
        }
    }
}
