using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var connections = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connections[i] = new List<int>();
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connections[ab[0]].Add(ab[1]);
                connections[ab[1]].Add(ab[0]);
            }

            var sign = new int[N + 1];
            for (int i = 0; i < N + 1; i++) sign[i] = -1;
            sign[1] = 0;
            var queue = new Queue<int>();
            queue.Enqueue(1);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (int r in connections[current])
                {
                    if (sign[r] == -1)
                    {
                        sign[r] = current;
                        queue.Enqueue(r);
                    }
                }
            }

            Console.WriteLine("Yes");
            for (int i = 2; i < N + 1; i++) Console.WriteLine(sign[i]);
        }
    }
}
