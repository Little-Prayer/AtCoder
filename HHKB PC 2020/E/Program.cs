using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            long MOD = 1000000007;

            var map = new bool[W, H];
            var K = H * W;
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++)
                {
                    map[j, i] = read[j] == '.';
                    if (read[j] == '#') K--;
                }
            }
            long allPatern = modPow(2, K, MOD);

            var Vertical = new List<int>[W];
            for (int i = 0; i < W; i++)
            {
                Vertical[i] = new List<int>();
                Vertical[i].Add(-1);
            }
            var Horizontal = new List<int>[H];
            for (int i = 0; i < H; i++)
            {
                Horizontal[i] = new List<int>();
                Horizontal[i].Add(-1);
            }
            for (int h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    if (!map[w, h])
                    {
                        Vertical[w].Add(h);
                        Horizontal[h].Add(w);
                    }
                }
            }
            for (int h = 0; h < H; h++) Horizontal[h].Add(W);
            for (int w = 0; w < W; w++) Vertical[w].Add(H);

            long result = 0;
            for (int h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    if (map[w, h])
                    {
                        var w1 = lower_bound(0, Horizontal[h].Count - 1, n => Horizontal[h][n] > w);
                        var width = Horizontal[h][w1] - Horizontal[h][w1 - 1] - 1;
                        var h1 = lower_bound(0, Vertical[w].Count - 1, n => Vertical[w][n] > h);
                        var height = Vertical[w][h1] - Vertical[w][h1 - 1] - 1;

                        var lamps = width + height - 1;

                        long pattern = allPatern - modPow(2, lamps, MOD);
                        if (pattern < 0) pattern += MOD;
                        result += pattern;
                        result %= MOD;
                    }
                }
            }
            Console.WriteLine(result);
        }

        static long modPow(long a, long n, long mod)
        {
            long result = 1;
            while (n > 0)
            {
                if ((n & 1) > 0) result = result * a % mod;
                a = a * a % mod;
                n >>= 1;
            }
            return result;
        }
        static int lower_bound(int ng, int ok, Func<int, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                int mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }
}
