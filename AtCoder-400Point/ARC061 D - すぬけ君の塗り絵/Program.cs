using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC061_D___すぬけ君の塗り絵
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWN = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HWN[0];
            var W = HWN[1];
            var N = HWN[2];

            var colored = new HashSet<Point>();
            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                colored.Add(new Point(ab[0], ab[1]));
            }

            var checking = new HashSet<Point>();
            foreach (Point p in colored)
            {
                for (int a = p.X - 1; a <= p.X + 1; a++)
                {
                    for (int b = p.Y - 1; b <= p.Y + 1; b++)
                    {
                        if (a <= 1 || a >= H || b <= 1 || b >= W) continue;
                        checking.Add(new Point(a, b));
                    }
                }
            }

            var result = new long[10];
            foreach (Point p in checking)
            {
                var count = 0;
                for (int h = p.X - 1; h <= p.X + 1; h++)
                {
                    for (int w = p.Y - 1; w <= p.Y + 1; w++)
                    {
                        if (colored.Contains(new Point(h, w))) count++;
                    }
                }
                result[count]++;
            }

            result[0] = (H - 2) * (W - 2);
            for (int i = 1; i < 10; i++) result[0] -= result[i];
            for (int i = 0; i < 10; i++) Console.WriteLine(result[i]);
        }
    }
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
