using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var DP = new long[N + 1, M + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    DP[i, j] = long.MinValue;
                }
            }

            for (int current = 1; current <= N; current++)
            {
                for (int pick = 1; pick <= Math.Min(M, current); pick++)
                {
                    DP[current, pick] = Math.Max(DP[current - 1, pick], DP[current - 1, pick - 1] + A[current - 1] * pick);
                }
            }

            Console.WriteLine(DP[N, M]);
        }
    }
}
