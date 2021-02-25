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
        public int length;
        List<Vector2> _snakeParts;
        bool _addPart;
        int _counter;
        int _updateTime;

        public int direction;
        
        public Snake(Texture2D tex, Color tint, Vector2 partSize, int updateTime)
        {
            _tex = tex;
            _tint = tint;
            _headPos = new Vector2(250, 250);
            _partSize = partSize;
            length = 1;
            direction = 3;
            _counter = 0;
            _updateTime = updateTime / 16;
            _snakeParts = new List<Vector2>();
            _snakeParts.Add(_headPos);
            _addPart = false;
        }

        public void AddPart()
        {
            if (!_addPart)
            {
                length++;
            }
            _addPart = true;
        }
        public void Update(GameTime gameTime, Rectangle screen)
        {
            if(_counter > _updateTime)
            {
                if(_addPart)
                {
                    _addPart = false;
                    _snakeParts.Add(new Vector2(0,0));
                }
                for (int i = _snakeParts.Count - 1; i > 0; i--)
                {
                    _snakeParts[i] = _snakeParts[i - 1];
                }

                switch (direction)
                {
                    case 1:
                        _headPos.Y -= _partSize.Y;
                        break;

                    case 2:
                        _headPos.X -= _partSize.X;
                        break;

                    case 3:
                        _headPos.Y += _partSize.Y;
                        break;

                    case 4:
                        _headPos.X += _partSize.X;
                        break;
                }
                _snakeParts[0] = _headPos;
                _counter = 0;
            }
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up))
            {
                direction = 1;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                direction = 2;
            }
            else if(ks.IsKeyDown(Keys.Down))
            {
                direction = 3;
            }
            else if(ks.IsKeyDown(Keys.Right))
            {
                direction = 4;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _counter++;
            foreach(Vector2 snake in _snakeParts)
            {
                spriteBatch.Draw(_tex, new Rectangle((int)snake.X, (int)snake.Y, (int)_partSize.X, (int)_partSize.Y), _tint);
            }
        }
    }
}
