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
            var X = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var bonus = new Dictionary<int, long>();
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                bonus.Add(read[0], read[1]);
            }

            var DP = new long[N + 1, N + 1];
            for (int total = 0; total < N; total++)
            {
                for (int counter = 0; counter <= total; counter++)
                {
                    DP[total + 1, 0] = Math.Max(DP[total, counter], DP[total + 1, 0]);
                    DP[total + 1, counter + 1] = DP[total, counter] + X[total];
                    if (bonus.ContainsKey(counter + 1)) DP[total + 1, counter + 1] += bonus[counter + 1];
                }
            }
            long result = DP[N, 0];
            for (int i = 0; i <= N; i++) result = Math.Max(result, DP[N, i]);
            Console.WriteLine(result);
        }
    }
}
