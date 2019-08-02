using System;
using System.Collections.Generic;

namespace ARC074_D___3N_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var front = new PriorityQueue<long>(true);
            for (int i = 0; i < N; i++) front.Push(Ai[i]);

            var center = new Deque<long>(N);
            for (int i = 0; i < N; i++) center.PushFront(Ai[i + N]);

            var back = new PriorityQueue<long>(false);
            for (int i = 0; i < N; i++) back.Push(Ai[i + 2 * N]);

            for (int i = 0; i < N; i++)
            {
                var removeFront = center.CheckFront() - front.Top();
                var removeBack = back.Top() - center.checkBack();
                if (removeFront < 0 && removeBack < 0)
                {
                    if (removeFront > removeBack)
                    {
                        center.PopBack();
                    }
                    else
                    {
                        center.PopFront();
                    }
                }
                else
                {
                    if (removeFront > removeBack)
                    {
                        front.Pop();
                        front.Push(center.PopFront());
                    }
                    else
                    {
                        back.Pop();
                        back.Push(center.PopBack());
                    }
                }
            }



        }
    }
    class Deque<T>
    {
        T[] buffer;
        int capacity, count, front;

        public Deque(int _capacity) { buffer = new T[capacity = 1 << _capacity]; }
        public Deque() { buffer = new T[capacity = 16]; }
        public Deque(T[] items)
        {
            buffer = items;
            capacity = items.Length;
            count = items.Length;
        }



        public void PushFront(T item)
        {
            if (capacity == count) extend();
            count += 1;
            if (front == 0) front = capacity;
            front -= 1;
            buffer[front] = item;
        }
        public void PushBack(T item)
        {
            if (capacity == count) extend();
            count += 1;
            buffer[(front + count - 1) % capacity] = item;
        }
        public T PopFront()
        {
            if (count == 0) throw new InvalidOperationException("collection is empty");
            var ret = buffer[front];
            front = front + 1 % capacity;
            count -= 1;
            return ret;
        }
        public T PopBack()
        {
            if (count == 0) throw new InvalidOperationException("collection is empty");
            var ret = (front + count - 1) % capacity;
            count -= 1;
            return buffer[ret];
        }

        public T CheckFront()
        {
            if (count == 0) throw new InvalidOperationException("collection is empty");
            return buffer[front];
        }
        public T checkBack()
        {
            if (count == 0) throw new InvalidOperationException("collection is empty");
            var ret = (front + count - 1) % capacity;
            return buffer[ret];
        }

        private void extend()
        {
            var newBuffer = new T[capacity << 1];
            if (front + count > capacity)
            {
                Array.Copy(buffer, front, newBuffer, 0, capacity - front);
                Array.Copy(buffer, 0, newBuffer, capacity - front, count - capacity + front);
            }
            else
            {
                Array.Copy(buffer, front, newBuffer, 0, count);
            }
            buffer = newBuffer;
            front = 0;
            capacity <<= 1;
        }

        public T[] toArray()
        {
            var ret = new T[count];
            if (front + count > capacity)
            {
                Array.Copy(buffer, front, ret, 0, capacity - front);
                Array.Copy(buffer, 0, ret, capacity - front, count - capacity + front);
            }
            else
            {
                Array.Copy(buffer, front, ret, 0, count);
            }
            return ret;
        }
    }
    class PriorityQueue<T> where T : IComparable
    {
        private List<T> nodes;
        private Boolean isAsc;

        public PriorityQueue(Boolean _isAsc)
        {
            this.nodes = new List<T>();
            this.isAsc = _isAsc;
        }

        public int Count()
        {
            return this.nodes.Count;
        }
        public T Pop()
        {
            T returnNode = this.nodes[0];
            this.nodes[0] = this.nodes[nodes.Count - 1];
            this.nodes.RemoveAt(nodes.Count - 1);
            int root = 0;
            while (root * 2 + 1 < this.nodes.Count)
            {
                int child = root * 2 + 1;
                if (child + 1 < this.nodes.Count && compare(this.nodes[child + 1], this.nodes[child]) > 0) child += 1;
                if (compare(this.nodes[child], this.nodes[root]) > 0)
                {
                    swap(child, root);
                    root = child;
                }
                else
                {
                    break;
                }
            }
            return returnNode;
        }
        public T Top()
        {
            return this.nodes[0];
        }
        public void Push(T t)
        {
            this.nodes.Add(t);
            var addPosition = nodes.Count - 1;
            while (addPosition > 0)
            {
                var parent = (int)(addPosition - 1) / 2;
                if (compare(nodes[addPosition], nodes[parent]) > 0)
                {
                    swap(addPosition, parent);
                    addPosition = parent;
                }
                else
                {
                    break;
                }
            }
        }
        private int compare(T x, T y)
        {
            return this.isAsc ? y.CompareTo(x) : x.CompareTo(y);
        }
        private void swap(int x, int y)
        {
            T temp = nodes[x];
            nodes[x] = nodes[y];
            nodes[y] = temp;
        }
    }
}
