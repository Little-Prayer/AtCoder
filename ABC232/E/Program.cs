using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HWK[0]; var W = HWK[1]; var K = HWK[2];
            var points = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var x1 = points[0]; var y1 = points[1]; var x2 = points[2]; var y2 = points[3];
            long MOD = 998244353;

            var DP = new long[K + 1, 4];
            if (x1 == x2 && y1 == y2) DP[0, 3] = 1;
            else if (x1 == x2) DP[0, 1] = 1;
            else if (y1 == y2) DP[0, 2] = 1;
            else DP[0, 0] = 1;

            for (int i = 1; i < K + 1; i++)
            {
                DP[i, 0] += (DP[i - 1, 0] * ((H - 2) + (W - 2) % MOD)) % MOD;
                DP[i, 0] += (DP[i - 1, 1] * (H - 1)) % MOD;
                DP[i, 0] += (DP[i - 1, 2] * (W - 1)) % MOD;
                DP[i, 0] %= MOD;
                DP[i, 1] += DP[i - 1, 0] % MOD;
                DP[i, 1] += (DP[i - 1, 1] * (W - 2)) % MOD;
                DP[i, 1] += (DP[i - 1, 3] * (W - 1)) % MOD;
                DP[i, 1] %= MOD;
                DP[i, 2] += DP[i - 1, 0] % MOD;
                DP[i, 2] += (DP[i - 1, 2] * (H - 2)) % MOD;
                DP[i, 2] += (DP[i - 1, 3] * (H - 1)) % MOD;
                DP[i, 2] %= MOD;
                DP[i, 3] += DP[i - 1, 1] % MOD;
                DP[i, 3] += DP[i - 1, 2] % MOD;
                DP[i, 3] %= MOD;
            }
            Console.WriteLine(DP[K, 3] % MOD);
        }
    }
}
