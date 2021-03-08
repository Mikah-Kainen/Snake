using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Snake.ScreenStuff
{
    public class MyStack<T> : IEnumerable
    {
        public int Count { get { return supportList.Count; } private set { } }
        List<T> supportList;
        public MyStack()
        {
            Count = 0;
            supportList = new List<T>();
        }

        public void Push(T value)
        {
            supportList.Add(value);
        }

        public T Pop()
        {
            T returnValue = Peek();
            supportList.Remove(supportList[supportList.Count - 1]);
            return returnValue;
        }

        public T Peek()
        {
            return supportList[supportList.Count - 1];
        }

        public void Clear()
        {
            supportList = new List<T>();
        }
        public IEnumerator GetEnumerator()
        {
            foreach(T value in supportList)
            {
                yield return value;
            }
        }
    }
}
