using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isVisit = new Dictionary<long, long>();
            var connection = new Dictionary<long, List<long>>();

            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                if (!connection.ContainsKey(ab[0])) connection.Add(ab[0], new List<long>());
                connection[ab[0]].Add(ab[1]);

                if (!connection.ContainsKey(ab[1])) connection.Add(ab[1], new List<long>());
                connection[ab[1]].Add(ab[0]);
            }
            long max = 1;
            var que = new Queue<long>();
            que.Enqueue(1);
            while (que.Count > 0)
            {
                var current = que.Dequeue();
                if (!connection.ContainsKey(current)) break;
                foreach (long q in connection[current])
                {
                    if (isVisit.ContainsKey(q)) continue;
                    isVisit.Add(q, 0);
                    if (max < q) max = q;
                    que.Enqueue(q);
                }
            }
            Console.WriteLine(max);
        }
    }
}
