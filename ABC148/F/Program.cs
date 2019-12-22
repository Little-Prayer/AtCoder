using System;
using System.Collections.Generic;

namespace F
{
    class Program
    {
        static void Main(string[] args)
        {
            var Nuv = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = Nuv[0]; var u = Nuv[1]; var v = Nuv[2];
            var connections = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connections[i] = new List<int>();
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connections[ab[0]].Add(ab[1]);
                connections[ab[1]].Add(ab[0]);
            }
            var distanceT = new int[N + 1];
            for (int i = 0; i < N + 1; i++) distanceT[i] = -1;
            distanceT[u] = 0;
            var queueT = new Queue<int>();
            queueT.Enqueue(u);
            while (queueT.Count > 0)
            {
                var current = queueT.Dequeue();
                foreach (int next in connections[current])
                {
                    if (distanceT[next] != -1) continue;
                    distanceT[next] = distanceT[current] + 1;
                    queueT.Enqueue(next);
                }
            }

            var distanceA = new int[N + 1];
            for (int i = 0; i < N + 1; i++) distanceA[i] = -1;
            distanceA[v] = 0;
            var queueA = new Queue<int>();
            queueA.Enqueue(v);
            while (queueA.Count > 0)
            {
                var current = queueA.Dequeue();
                foreach (int next in connections[current])
                {
                    if (distanceA[next] != -1) continue;
                    distanceA[next] = distanceA[current] + 1;
                    queueA.Enqueue(next);
                }
            }

            var end = 0;
            for (int i = 1; i < N + 1; i++)
            {
                if (distanceA[i] < distanceT[i]) continue;
                end = Math.Max(end, distanceA[i]);
            }
            Console.WriteLine(end - 1);
        }
    }
}
