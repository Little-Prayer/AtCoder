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

            var parent = new int[N + 1];
            parent[Y] = -1;
            var queue = new Queue<int>();
            queue.Enqueue(Y);
            while (true)
            {
                var current = queue.Dequeue();
                if (current == X) break;
                foreach (int c in tree[current])
                {
                    if (parent[c] == 0)
                    {
                        parent[c] = current;
                        queue.Enqueue(c);
                    }
                }
            }

            var route = new List<int>();
            var move = X;
            route.Add(X);
            while (parent[move] > 0)
            {
                route.Add(parent[move]);
                move = parent[move];
            }
            Console.WriteLine(string.Join(" ", route));
        }
    }
}
