using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var costs = new int[M + 1];
            var opens = new int[M + 1];
            for (int i = 1; i < M + 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                costs[i] = ab[0];
                var c = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                foreach (int op in c) opens[i] += 1 << (op - 1);
            }

            var DP = new int[M + 1, 1 << N];
            for (int i = 0; i < M + 1; i++) for (int j = 0; j < (1 << N); j++) DP[i, j] = int.MaxValue;
            DP[0, 0] = 0;
            for (int key = 0; key < M; key++)
            {
                for (int open = 0; open < (1 << N); open++)
                {
                    if (DP[key, open] == int.MaxValue) continue;
                    DP[key + 1, open] = Math.Min(DP[key + 1, open], DP[key, open]);
                    DP[key + 1, open | opens[key + 1]] = Math.Min(DP[key + 1, open | opens[key + 1]], DP[key, open] + costs[key + 1]);
                }
            }
            Console.WriteLine(DP[M, (1 << N) - 1] != int.MaxValue ? DP[M, (1 << N) - 1] : -1);
        }
    }
}
