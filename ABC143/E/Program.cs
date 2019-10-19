using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NML = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NML[0]; var M = NML[1]; var L = NML[2];
            var fuel = new long[N + 1, N + 1];
            for (int i = 0; i < N + 1; i++) for (int j = 0; j < N + 1; j++) fuel[i, j] = i != j ? long.MaxValue : 0;
            for (int i = 0; i < M; i++)
            {
                var abc = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                fuel[abc[0], abc[1]] = abc[2];
                fuel[abc[1], abc[0]] = abc[2];
            }
            for (int via = 1; via < N + 1; via++)
            {
                for (int from = 1; from < N + 1; from++)
                {
                    for (int to = 1; to < N + 1; to++)
                    {
                        if (fuel[via, from] == long.MaxValue || fuel[to, via] == long.MaxValue) continue;
                        if (fuel[from, to] > fuel[from, via] + fuel[via, to])
                        {
                            fuel[from, to] = fuel[from, via] + fuel[via, to];
                        }
                    }
                }
            }

            var resuplly = new int[N + 1, N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    resuplly[i, j] = fuel[i, j] <= L ? 0 : int.MaxValue;
                }
            }

            for (int via = 1; via < N + 1; via++)
            {
                for (int from = 1; from < N + 1; from++)
                {
                    for (int to = 1; to < N + 1; to++)
                    {
                        if (resuplly[from, via] == int.MaxValue || resuplly[via, to] == int.MaxValue) continue;
                        if (resuplly[from, to] > resuplly[from, via] + resuplly[via, to] + 1)
                        {
                            resuplly[from, to] = resuplly[from, via] + resuplly[via, to] + 1;
                        }
                    }
                }
            }

            var Q = int.Parse(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                var st = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(resuplly[st[0], st[1]] != int.MaxValue ? resuplly[st[0], st[1]] : -1);
            }

        }
    }
}