using System;
using System.Collections.Generic;

namespace D___Ki
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0];
            var Q = NQ[1];
            var connections = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connections[i] = new List<int>();
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connections[ab[0]].Add(ab[1]);
                connections[ab[1]].Add(ab[0]);
            }

            var counter = new long[N];
            for (int i = 0; i < Q; i++)
            {
                var px = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                counter[px[0] - 1] += px[1];
            }

            var isSearch = new bool[N + 1];
            for (int i = 0; i < N + 1; i++) isSearch[i] = false;
            var queue = new Queue<int>();
            queue.Enqueue(1);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                isSearch[current] = true;
                foreach (int child in connections[current])
                {
                    if (isSearch[child]) continue;
                    counter[child - 1] += counter[current - 1];
                    queue.Enqueue(child);
                }
            }
            Console.WriteLine(string.Join(" ", counter));
        }
    }
}
