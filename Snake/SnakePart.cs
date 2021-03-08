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
        private Snake parentSnake;

        public Vector2 Loc;
        public float X => Loc.X;
        public float Y => Loc.Y;

        public Vector2 Size => parentSnake.PartSize;

        public Rectangle HitBox => new Rectangle((int)X, (int)Y, (int)Size.X, (int)Size.Y);
        
        public SnakePart(Vector2 loc, Snake parentSnake)
        {
            this.parentSnake = parentSnake;

            Loc = loc;
        }

        public SnakePart(int x, int y, Vector2 size, Snake parentSnake)
            : this(new Vector2(x, y), parentSnake) { }
    }
}
