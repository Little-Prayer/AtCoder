using System;
using System.Collections.Generic;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(A);
            var de = new Deque<int>();
            for (int i = 0; i < N; i++) de.PushBack(A[i]);

            var result = 0;
            while (de.count > 1)
            {
                var max = de.PopBack();
                var min = de.CheckFront();

                if ((max % min) > 0) de.PushFront((max % min));
                result++;
            }
            Console.WriteLine(result);
        }
    }

    class Deque<T>
    {
        T[] buffer;
        public int capacity;
        public int count;
        public int front;

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
            front = (front + 1) % capacity;
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
}
