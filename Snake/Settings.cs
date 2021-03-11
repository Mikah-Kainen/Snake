using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Settings
    {
        public Dictionary<Keys, Directions> DirectionDictionary { get; private set; }
        public Dictionary<Keys, Screens> CommandDictionary { get; private set; }

        public Settings()
        {
            DirectionDictionary = new Dictionary<Keys, Directions>()
            {
                [Keys.Up] = Directions.Up,
                [Keys.Left] = Directions.Left,
                [Keys.Down] = Directions.Down,
                [Keys.Right] = Directions.Right,
            };

            CommandDictionary = new Dictionary<Keys, Screens>()
            {
                [Keys.Space] = Screens.Pause,
            };
        }
    }
}
