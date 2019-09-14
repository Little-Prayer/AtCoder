using System;
using System.Collections.Generic;

namespace ATC001_A___深さ優先探索
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];

            var map = new char[H, W];
            Point start = new Point(0, 0);
            for (int h = 0; h < H; h++)
            {
                var read = Console.ReadLine();
                for (int w = 0; w < W; w++)
                {
                    map[h, w] = read[w];
                    if (map[h, w] == 's') start = new Point(h, w);
                }
            }

            var isSearch = new bool[H, W];
            var stack = new Stack<Point>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                if (map[cur.H, cur.W] == 'g') return true;
                isSearch[cur.H, cur.W] = true;
                if (cur.H > 0 && map[cur.H - 1, cur.W] != '#' && !isSearch[cur.H - 1, cur.W]) stack.Push(new Point(cur.H - 1, cur.W));
                if (cur.H < H - 1 && map[cur.H + 1, cur.W] != '#' && !isSearch[cur.H + 1, cur.W]) stack.Push(new Point(cur.H + 1, cur.W));
                if (cur.W > 0 && map[cur.H, cur.W - 1] != '#' && !isSearch[cur.H, cur.W - 1]) stack.Push(new Point(cur.H, cur.W - 1));
                if (cur.W < W - 1 && map[cur.H, cur.W + 1] != '#' && !isSearch[cur.H, cur.W + 1]) stack.Push(new Point(cur.H, cur.W + 1));
            }
            return false;
        }

        struct Point
        {
            public int H;
            public int W;
            public Point(int h, int w)
            {
                H = h;
                W = w;
            }
        }
    }
}
