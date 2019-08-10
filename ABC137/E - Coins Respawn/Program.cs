using System;

namespace E___Coins_Respawn
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMP = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NMP[0];
            var M = NMP[1];
            var P = NMP[2];

            var edges = new edge[M];
            for (int i = 0; i < M; i++)
            {
                var e = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                edges[i] = new edge(e[0], e[1], P - e[2]);
            }
            var distance = new long[N + 1];
            for (int i = 0; i < N + 1; i++) distance[i] = long.MaxValue;
            distance[1] = 1;
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var e = edges[j];
                    if (distance[e.from] == long.MaxValue) continue;
                    if (distance[e.to] > distance[e.from] + e.cost)
                    {
                        distance[e.to] = distance[e.from] + e.cost;
                        if (i == N)
                        {
                            if (e.to == N) distance[N] = -1;
                        }
                    }
                }
            }
            if (distance[N] != -1)
            {
                Console.WriteLine(Math.Max(0, distance[N] * -1));
            }
            else
            {
                Console.WriteLine("-1");
            }

        }
    }

    struct edge
    {
        public long from;
        public long to;
        public long cost;

        public edge(long _from, long _to, long _cost)
        {
            from = _from;
            to = _to;
            cost = _cost;
        }

    }
}
