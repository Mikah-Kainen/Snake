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
        public Vector2 PartSize { get; private set; }

        public CircularLinked<SnakePart> snakeParts;
        bool _addPart;
        int _counter;
        int _updateTime;
        Dictionary<Keys, Directions> _directions;
        Rectangle _screen;

        public Queue<Keys> pressedKeys;
        public Directions direction;
        
        public Snake(Texture2D tex, Color tint, Vector2 partSize, int updateTime, Dictionary<Keys, Directions> directions, Rectangle screen)
        {
            _tex = tex;
            _tint = tint;
            PartSize = partSize;
            direction = Directions.None;
            _counter = 0;
            _updateTime = updateTime / 16;
            snakeParts = new CircularLinked<SnakePart>();
            snakeParts.Add(new SnakePart(250, 250, partSize, this));
            _addPart = false;
            pressedKeys = new Queue<Keys>();

            _directions = directions;
            _screen = screen;
        }

        public void AddPart()
        {
            _addPart = true;
        }
        public void Update(GameTime gameTime)
        {
            if(_counter > _updateTime)
            {
                if (pressedKeys.Count > 0)
                {
                    direction = _directions[pressedKeys.Dequeue()];
                }
                if (_addPart && direction != Directions.None)
                {
                    _addPart = false;
                    snakeParts.Add(new SnakePart(0, 0, PartSize, this));
                }
                for (int i = snakeParts.Count - 1; i > 0; i--)
                {
                    snakeParts[i].Loc = snakeParts[i - 1].Loc;
                }

                switch (direction)
                {
                    case Directions.Up:
                        snakeParts[0].Loc.Y -= PartSize.Y;
                        break;

                    case Directions.Left:
                        snakeParts[0].Loc.X -= PartSize.X;
                        break;

                    case Directions.Down:
                        snakeParts[0].Loc.Y += PartSize.Y;
                        break;

                    case Directions.Right:
                        snakeParts[0].Loc.X += PartSize.X;
                        break;

                }
                _counter = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _counter++;
            foreach(SnakePart snake in snakeParts)
            {
                spriteBatch.Draw(_tex, new Rectangle((int)snake.X, (int)snake.Y, (int)PartSize.X, (int)PartSize.Y), _tint);
            }
        }
    }
}
