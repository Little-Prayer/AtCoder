using System;
using System.Collections.Generic;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NXY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NXY[0]; var X = NXY[1]; var Y = NXY[2];
            var tree = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) tree[i] = new List<int>();
            for (int i = 0; i < N - 1; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                tree[read[0]].Add(read[1]);
                tree[read[1]].Add(read[0]);
            }

            var isRoute = new bool[N + 1];
            var queue = new Queue<int>();
            queue.Enqueue(X);
            while (true)
            {
                var current = queue.Dequeue();
                isRoute[current] = true;
                if (current == Y) break;
                foreach (int c in tree[current]) if (!isRoute[c]) queue.Enqueue(c);
            }

            var route = new List<int>();
            route.Add(Y);
            var current2 = Y;
            var isChecked = new bool[N + 1];
            while (true)
            {
                if (current2 == X) break;
                isChecked[current2] = true;
                foreach (int c in tree[current2])
                {
                    if (isRoute[c] && !isChecked[c])
                    {
                        route.Add(c);
                        current2 = c;
                        break;
                    }
                }
            }
            var R = route.ToArray();
            Array.Reverse(R);
            Console.WriteLine(string.Join(" ", R));
        }
    }
}
