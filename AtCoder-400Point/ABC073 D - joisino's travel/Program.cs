using System;

namespace ABC073_D___joisino_s_travel
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = read[0];
            var M = read[1];
            var R = read[2];

            var ri = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var distance = new int[N + 1, N + 1];
            for (int i = 0; i < N + 1; i++) for (int j = 0; j < N + 1; j++) distance[i, j] = int.MaxValue;
            for (int i = 1; i < N + 1; i++) distance[i, i] = 0;

            for (int i = 0; i < M; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                distance[read[0], read[1]] = read[2];
                distance[read[1], read[0]] = read[2];
            }

            for (int via = 1; via < N + 1; via++)
                for (int to = 1; to < N + 1; to++)
                    for (int from = 1; from < N + 1; from++)
                    {
                        if (distance[to, via] == int.MaxValue || distance[via, from] == int.MaxValue) continue;
                        if (distance[to, via] + distance[via, from] < distance[from, to]) distance[from, to] = distance[to, via] + distance[via, from];
                    }

            var distanceR = new int[R, R];
            for (int i = 0; i < R; i++) for (int j = 0; j < R; j++) distanceR[i, j] = distance[ri[i], ri[j]];

            var dp = new long[1 << R];
            dp[0] = 0;
            for (int i = 1; i < dp.Length; i++) dp[i] = int.MaxValue;
            for (int i = 0; i < R; i++) dp[1 << i] = 0;

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < R; j++)
                {
                    if (((1 << j) & i) > 0)
                    {
                        for (int k = 0; k < R; k++)
                        {
                            if (k == j) continue;
                            if (((1 << k) & i) > 0) dp[i] = Math.Min(dp[i], dp[i - j] + distanceR[j, k]);
                        }
                    }
                }
            }
            Console.WriteLine(dp[(1 << R) - 1]);
        }
    }
}
