﻿using System;

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

            var distance = new long[N + 1, N + 1];
            for (int i = 0; i < N + 1; i++) for (int j = 0; j < N + 1; j++) distance[i, j] = long.MaxValue;
            for (int i = 0; i < N + 1; i++) distance[i, i] = 0;

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
                        if (distance[to, via] == long.MaxValue || distance[via, from] == long.MaxValue) continue;
                        distance[from, to] = Math.Min(distance[from, to], distance[from, via] + distance[via, to]);
                    }

            var distanceR = new long[R, R];
            for (int i = 0; i < R; i++) for (int j = 0; j < R; j++) distanceR[i, j] = distance[ri[i], ri[j]];

            var dp = new long[1 << R, R];
            for (int i = 0; i < (1 << R); i++) for (int j = 0; j < R; j++) dp[i, j] = long.MaxValue;
            for (int i = 0; i < R; i++) dp[1 << i, i] = 0;

            for (int bit = 1; bit < (1 << R); bit++)
                for (int last = 0; last < R; last++)
                {
                    if ((bit & (1 << last)) == 0) continue;
                    for (int prev = 0; prev < R; prev++)
                        if (((1 << prev) & (bit - (1 << last))) > 0) dp[bit, last] = Math.Min(dp[bit, last], dp[bit - (1 << last), prev] + distanceR[last, prev]);
                }

            long result = long.MaxValue;
            for (int i = 0; i < R; i++) result = Math.Min(result, dp[(1 << R) - 1, i]);
            Console.WriteLine(result);
        }
    }
}
