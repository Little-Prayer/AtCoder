using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            var connection = new List<(int node, bool sw)>[2 * N + 1];
            for (int i = 0; i < connection.Length; i++) { connection[i] = new List<(int, bool)>(); }
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (read[2] == 1)
                {
                    connection[read[0]].Add((read[1], false));
                    connection[read[1]].Add((read[0], false));
                }
                else
                {
                    connection[read[0] + N].Add((read[1] + N, false));
                    connection[read[1] + N].Add((read[0] + N, false));
                }
            }
            if (K > 0)
            {
                var sw = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                foreach (int s in sw)
                {
                    connection[s].Add((s + N, true));
                    connection[s + N].Add((s, true));
                }
            }
            var move = new int[2 * N + 1];
            for (int i = 0; i <= 2 * N; i++) { move[i] = int.MaxValue; }
            move[1] = 0;
            var de = new Deque<int>();
            de.PushFront(1);
            while (de.count > 0)
            {
                var current = de.PopFront();
                foreach (var route in connection[current])
                {
                    if (route.sw)
                    {
                        if (move[route.node] <= move[current]) { continue; }
                        move[route.node] = move[current];
                        de.PushFront(route.node);
                    }
                    else
                    {
                        if (move[route.node] <= move[current] + 1) { continue; }
                        move[route.node] = move[current] + 1;
                        de.PushBack(route.node);
                    }
                }
            }
            var result = Math.Min(move[N], move[2 * N]);
            if (result == int.MaxValue) result = -1;
            Console.WriteLine(result);
        }
    }
    class Deque<T>
    {
        T[] buffer;
        public int capacity, count, front;

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

