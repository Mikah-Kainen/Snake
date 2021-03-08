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
        Dictionary<Keys, Direction> _directions;
        Queue<Keys> _pressedKeys;
        Keys _lastKeyPressed;
        Rectangle _screen;

        public Direction direction;
        
        public Snake(Texture2D tex, Color tint, Vector2 partSize, int updateTime, Dictionary<Keys, Direction> directions, Rectangle screen)
        {
            _tex = tex;
            _tint = tint;
            PartSize = partSize;
            direction = Direction.None;
            _counter = 0;
            _updateTime = updateTime / 16;
            snakeParts = new CircularLinked<SnakePart>();
            snakeParts.Add(new SnakePart(250, 250, partSize, this));
            _addPart = false;
            _pressedKeys = new Queue<Keys>();
            _lastKeyPressed = Keys.None;

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
                if (_pressedKeys.Count > 0)
                {
                    direction = _directions[_pressedKeys.Dequeue()];
                }
                if (_addPart && direction != Direction.None)
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
                    case Direction.Up:
                        snakeParts[0].Loc.Y -= PartSize.Y;
                        break;

                    case Direction.Left:
                        snakeParts[0].Loc.X -= PartSize.X;
                        break;

                    case Direction.Down:
                        snakeParts[0].Loc.Y += PartSize.Y;
                        break;

                    case Direction.Right:
                        snakeParts[0].Loc.X += PartSize.X;
                        break;

                }
                _counter = 0;
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
