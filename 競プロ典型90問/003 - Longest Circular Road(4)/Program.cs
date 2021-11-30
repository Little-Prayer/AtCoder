using System;
using System.Collections.Generic;

namespace _003___Longest_Circular_Road
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var tree = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) tree[i] = new List<int>();

            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var a = ab[0]; var b = ab[1];

                tree[a].Add(b);
                tree[b].Add(a);
            }
            var (x, y) = BFS(tree, 1);
            var (u, v) = BFS(tree, y);

            Console.WriteLine(u + 1);
        }

        static (int, int) BFS(List<int>[] tree, int start)
        {
            var seen = new bool[tree.Length + 1];
            for (int i = 0; i < tree.Length + 1; i++) seen[i] = false;
            var distance = new int[tree.Length + 1];
            var maxDistance = 0;
            var maxLeaf = start;

            var queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                seen[current] = true;
                foreach (int i in tree[current])
                {
                    distance[i] = distance[current] + 1;
                    if (distance[i] > maxDistance)
                    {
                        maxDistance = distance[i];
                        maxLeaf = i;
                    }
                    if (!seen[i]) queue.Enqueue(i);
                }
            }
            return (maxDistance, maxLeaf);
        }
    }
}
