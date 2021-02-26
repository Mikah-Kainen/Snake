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
        public Vector2 Loc;
        public float X => Loc.X;
        public float Y => Loc.Y;

        public Vector2 Size;

        public Rectangle HitBox => new Rectangle((int)X, (int)Y, (int)Size.X, (int)Size.Y);
        public SnakePart(Vector2 loc, Vector2 size)
        {
            Loc = loc;
            Size = size;
        }

        public SnakePart(int x, int y, Vector2 size)
        {
            Loc = new Vector2(x, y);
            Size = size;
        }
    }
}
