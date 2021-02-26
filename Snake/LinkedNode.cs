using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class LinkedNode<T>
    {
        public T Value;
        public LinkedNode<T> Next { get; set; }
        public LinkedNode<T> Previous { get; set; }
        public LinkedNode(T value)
        {
            Value = value;
        }
    }
}
