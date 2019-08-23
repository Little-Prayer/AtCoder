using System;

namespace ABC113_D___Number_of_Amidakuji
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var HWK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HWK[0];
            var W = HWK[1];
            var K = HWK[2];
            if (W == 1) return 1;
            long MOD = 1000000007;

            var amida1 = new long[W + 1];
            for (int i = 1; i < W; i++)
            {
                var DP = new long[W, 2];
                DP[0, 0] = 1;
                for (int j = 1; j < W; j++)
                {
                    DP[j, 1] = DP[j - 1, 0];
                    DP[j, 0] = j == i ? 0 : (DP[j - 1, 0] + DP[j - 1, 1]) % MOD;
                }
                amida1[i] = (DP[W - 1, 0] + DP[W - 1, 1]) % MOD;
            }

            var amida2 = new long[W + 1];
            for (int i = 1; i < W + 1; i++)
            {
                var DP = new long[W + 1, 2];
                DP[0, 0] = 1;
                for (int j = 1; j < W + 1; j++)
                {
                    DP[j, 1] = j == i || j == i - 1 ? 0 : DP[j - 1, 0];
                    DP[j, 0] = (DP[j - 1, 0] + DP[j - 1, 1]) % MOD;
                }
                amida2[i] = (DP[W - 1, 0] + DP[W - 1, 1]) % MOD;
            }

            var mainDP = new long[H + 1, W + 2];
            mainDP[0, 1] = 1;
            for (int h = 1; h < H + 1; h++)
            {
                for (int w = 1; w < W + 1; w++)
                {
                    mainDP[h, w] += (mainDP[h - 1, w] * amida2[w]) % MOD;
                    mainDP[h, w] += (mainDP[h - 1, w - 1] * amida1[w - 1]) % MOD;
                    mainDP[h, w] += (mainDP[h - 1, w + 1] * amida1[w]) % MOD;
                    mainDP[h, w] %= MOD;
                }
            }
            return mainDP[H, K];
        }
    }
}
