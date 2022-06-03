using System;
using System.Collections.Generic;
using System.Linq;

namespace _043___Maze_Challenge_with_Lack_of_Sleep_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var start = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var goal = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            start[0]--; start[1]--; goal[0]--; goal[1]--;

            var map = new int[H, W, 4];
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) for (int k = 0; k < 4; k++) map[i, j, k] = int.MaxValue;
            for (int i = 0; i < 4; i++) map[start[0], start[1], i] = 0;
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++)
                    if (read[j] == '#')
                        for (int k = 0; k < 4; k++)
                            map[i, j, k] = -1;
            }

            var deque = new Deque<(int row, int column, int direction, int count)>();
            if (start[0] >= 1) deque.PushFront((start[0] - 1, start[1], 0, 0));
            if (start[0] <= H - 1) deque.PushFront((start[0] + 1, start[1], 2, 0));
            if (start[1] <= H - 1) deque.PushFront((start[0], start[1] + 1, 3, 0));
            if (start[1] >= 1) deque.PushFront((start[0], start[1] - 1, 1, 0));

            while (deque.count > 0)
            {
                var current = deque.PopFront();
                for (int i = 0; i < 4; i++) map[current.row, current.column, i] = current.direction == i ? current.count : current.count + 1;

            }
        }
    }
    class Deque<T>
    {
        T[] buffer;
        int capacity, front;
        public int count;

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
}
