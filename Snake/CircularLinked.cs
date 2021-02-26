using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class CircularLinked<T> : IEnumerable<T>
    {
        public LinkedNode<T> Head { get; set; }
        public int Count;
        public CircularLinked()
        {
            Count = 0;
        }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new LinkedNode<T>(value);
            }
            else
            {
                LinkedNode<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new LinkedNode<T>(value);
                currentNode.Next.Previous = currentNode;
            }

            Count++;
        }

        public void Clear()
        {
            if (Head == null)
            {
                return;
            }
            while (Head.Next != null)
            {
                Head.Next = null;
            }
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if(index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    LinkedNode<T> currentNode = Head;
                    for(int i = 0; i < index; i ++)
                    {
                        currentNode = currentNode.Next;
                    }
                    return currentNode.Value;
                }
            }

            set
            {

            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> currentNode = Head;
            for(int i = 0; i < Count; i ++)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
