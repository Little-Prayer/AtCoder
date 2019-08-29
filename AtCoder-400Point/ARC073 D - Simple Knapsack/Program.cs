using System;

namespace ARC073_D___Simple_Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NW[0];
            var W = NW[1];
            var wv1 = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var w1 = wv1[0];
            if (w1 > W) return 0;
            var v1 = wv1[1];

            var DP = new long[N + 1, N + 1, 1000 + 1];
            for (int i = 0; i < 1000 + 1; i++) DP[1, 1, i] = v1;

            for (int item = 2; item < N + 1; item++)
            {
                var wv = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                var w = (int)(wv[0] - w1);
                var v = wv[1];
                for (int count = 1; count <= item; count++)
                {
                    for (int weight = 0; weight < 1000 + 1; weight++)
                    {
                        DP[item, count, weight] = weight >= w ? Math.Max(DP[item - 1, count, weight], DP[item - 1, count - 1, weight - w] + v) : DP[item - 1, count, weight];
                    }
                }
            }

            long result = 0;
            var countMin = W / (w1 + 3);
            var countMax = Math.Min(W / w1, N);
            for (long c = countMin; c <= countMax; c++)
                result = Math.Max(result, DP[N, c, Math.Min(1000, W - w1 * c)]);

            return result;
        }
    }
}
