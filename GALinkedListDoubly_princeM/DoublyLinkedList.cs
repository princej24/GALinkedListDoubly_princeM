using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static GALinkedListDoubly_princeM.DoublyLinkedList<T>;

namespace GALinkedListDoubly_princeM
{
    public class DoublyLinkedList<T>
    {
        public class LinkedListNode
        {
            public T Value { get; internal set; }
            public LinkedListNode Next { get; internal set; }
            public LinkedListNode Previous { get; internal set; }

            public LinkedListNode(T value)
            {
                Value = value;
            }
        }

        private LinkedListNode _head;
        private LinkedListNode _tail;
        private int _count;

        public int Count => _count;

        // Constructor
        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Add(T value)
        {
            LinkedListNode newNode = new LinkedListNode(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public void DisplayForward()
        {
            LinkedListNode current = _head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void DisplayBackward()
        {
            LinkedListNode current = _tail;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Previous;
            }
            Console.WriteLine();
        }

        public void Remove(T value)
        {
            LinkedListNode current = _head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current == _head)
                    {
                        _head = current.Next;
                        if (_head != null)
                            _head.Previous = null;
                    }
                    else if (current == _tail)
                    {
                        _tail = current.Previous;
                        if (_tail != null)
                            _tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    _count--;
                    return;
                }
                current = current.Next;
            }
        }

        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                InsertAtFront(value);
                return;
            }

            if (index == _count)
            {
                Add(value);
                return;
            }

            LinkedListNode newNode = new LinkedListNode(value);
            LinkedListNode current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Previous = current;
            current.Next.Previous = newNode;
            current.Next = newNode;
            _count++;
        }

        
        public void InsertAtFront(T value)
        {
            LinkedListNode newNode = new LinkedListNode(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }
            _count++;
        }

        public void InsertAtEnd(T value)
        {
            Add(value);
        }

        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                RemoveAtFront();
                return;
            }

            if (index == _count - 1)
            {
                RemoveAtEnd();
                return;
            }

            LinkedListNode current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            _count--;
        }

        public void RemoveAtFront()
        {
            if (_head == null)
                throw new InvalidOperationException("List is empty");

            _head = _head.Next;
            if (_head != null)
                _head.Previous = null;
            else
                _tail = null;
            _count--;
        }

        public void RemoveAtEnd()
        {
            if (_tail == null)
                throw new InvalidOperationException("List is empty");

            _tail = _tail.Previous;
            if (_tail != null)
                _tail.Next = null;
            else
                _head = null;
            _count--;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                LinkedListNode current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                LinkedListNode current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }
    }


}
