using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public enum Directions
    {
        Up = 1,
        Left,
        Down,
        Right,
        None,
    }

    public enum Screens
    {
        Game,
        Test,
        Replay,
        Settings,
        Pause,
    }

    public enum Commands
    {
        Pause,
    }
}
