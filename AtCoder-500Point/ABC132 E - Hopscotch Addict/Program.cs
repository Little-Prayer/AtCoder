using System;
using System.Collections.Generic;

namespace ABC132_E___Hopscotch_Addict
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var nodes = new List<int>[3 * NM[0] + 3];
            for (int i = 1; i < 3 * NM[0] + 3; i++) nodes[i] = new List<int>();
            for (int i = 0; i < NM[1]; i++)
            {
                var edge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var from = edge[0];
                var to = edge[1];
                nodes[3 * from].Add(3 * to + 1);
                nodes[3 * from + 1].Add(3 * to + 2);
                nodes[3 * from + 2].Add(3 * to);
            }
            var ST = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var distance = new int[3 * NM[0] + 3];
            for (int i = 0; i < distance.Length; i++) distance[i] = int.MaxValue;
            distance[ST[0] * 3] = 0;
            var queue = new Queue<int>();
            queue.Enqueue(3 * ST[0]);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                foreach (int to in nodes[current])
                {
                    if (distance[to] > distance[current] + 1)
                    {
                        distance[to] = distance[current] + 1;
                        queue.Enqueue(to);
                        if (to == ST[1] * 3) break;
                    }

                }
            }
            Console.WriteLine(distance[3 * ST[1]] == int.MaxValue ? -1 : distance[3 * ST[1]] / 3);
        }
    }
}
