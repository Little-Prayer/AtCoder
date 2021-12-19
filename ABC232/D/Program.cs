using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var map = new bool[H, W];
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++) map[i, j] = (read[j] == '.');
            }

            var queue = new Queue<Point>();
            queue.Enqueue(new Point(0, 0));
            var count = new int[H, W];
            count[0, 0] = 1;
            var result = 1;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Height < H - 1 && map[current.Height + 1, current.Width] && count[current.Height + 1, current.Width] == 0)
                {
                    count[current.Height + 1, current.Width] = count[current.Height, current.Width] + 1;
                    queue.Enqueue(new Point(current.Height + 1, current.Width));
                    if (result < count[current.Height, current.Width] + 1) result = count[current.Height, current.Width] + 1;
                }
                if (current.Width < W - 1 && map[current.Height, current.Width + 1] && count[current.Height, current.Width + 1] == 0)
                {
                    count[current.Height, current.Width + 1] = count[current.Height, current.Width] + 1;
                    queue.Enqueue(new Point(current.Height, current.Width + 1));
                    if (result < count[current.Height, current.Width] + 1) result = count[current.Height, current.Width] + 1;
                }
            }
            Console.WriteLine(result);
        }
        class Point
        {
            public int Height { get; }
            public int Width { get; }

            public Point(int h, int w)
            {
                Height = h;
                Width = w;
            }
        }
    }
}
