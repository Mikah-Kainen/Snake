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
        Vector2 _partSize;
        public CircularLinked<SnakePart> snakeParts;
        bool _addPart;
        int _counter;
        int _updateTime;
        Dictionary<Keys, Direction> _directions;
        Queue<Keys> _pressedKeys;
        Keys _lastKeyPressed;


        public Direction direction;
        
        public Snake(Texture2D tex, Color tint, Vector2 partSize, int updateTime, Dictionary<Keys, Direction> directions)
        {
            _tex = tex;
            _tint = tint;
            _partSize = partSize;
            direction = Direction.None;
            _counter = 0;
            _updateTime = updateTime / 16;
            snakeParts = new CircularLinked<SnakePart>();
            snakeParts.Add(new SnakePart(250, 250, _partSize));
            _addPart = false;
            _pressedKeys = new Queue<Keys>();
            _lastKeyPressed = Keys.None;

            _directions = directions;
        }

        public void AddPart()
        {
            _addPart = true;
        }
        public bool Update(GameTime gameTime, Rectangle screen)
        {
            if(_counter > _updateTime)
            {
                if (_pressedKeys.Count > 0)
                {
                    direction = _directions[_pressedKeys.Dequeue()];
                }
                if (_addPart && direction != Direction.None)
                {
                    _addPart = false;
                    snakeParts.Add(new SnakePart(0, 0, _partSize));
                }
                for (int i = snakeParts.Count - 1; i > 0; i--)
                {
                    snakeParts[i].Loc = snakeParts[i - 1].Loc;
                }

                switch (direction)
                {
                    case Direction.Up:
                        snakeParts[0].Loc.Y -= _partSize.Y;
                        break;

                    case Direction.Left:
                        snakeParts[0].Loc.X -= _partSize.X;
                        break;

                    case Direction.Down:
                        snakeParts[0].Loc.Y += _partSize.Y;
                        break;

                    case Direction.Right:
                        snakeParts[0].Loc.X += _partSize.X;
                        break;

                }
                _counter = 0;

                if (snakeParts[0].X + _partSize.X > screen.Right || snakeParts[0].X < screen.Left || snakeParts[0].Y + _partSize.Y > screen.Bottom || snakeParts[0].Y < screen.Top)
                {
                    return true;
                }
                for(int i = 1; i < snakeParts.Count; i ++)
                {
                    if(snakeParts[0].HitBox.Intersects(snakeParts[i].HitBox))
                    {
                        return true;
                    }
                }
            }
            KeyboardState ks = Keyboard.GetState();

            //store get pressed keys in an array
            //foreach through that array and if the directionary does not contain the key, then continune
            //otherwise set direction to whatever dictionary[item] is

            var input = ks.GetPressedKeys();
            foreach(Keys key in input)
            {
                if (_directions.ContainsKey(key) && key != _lastKeyPressed)
                {
                    _lastKeyPressed = key;
                    _pressedKeys.Enqueue(key);
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _counter++;
            foreach(SnakePart snake in snakeParts)
            {
                spriteBatch.Draw(_tex, new Rectangle((int)snake.X, (int)snake.Y, (int)_partSize.X, (int)_partSize.Y), _tint);
            }
        }
    }
}
