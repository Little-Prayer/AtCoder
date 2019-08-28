using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC061_D___すぬけ君の塗り絵
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWN = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HWN[0];
            var W = HWN[1];
            var N = HWN[2];
            long MOD = 1000000007;

            var colored = new HashSet<long>();
            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                colored.Add(ab[0] + ab[1] * MOD);
            }

            var checking = new HashSet<long>();
            foreach (long p in colored)
            {
                var h = p % MOD;
                var w = p / MOD;
                for (long a = h - 1; a <= h + 1; a++)
                {
                    for (long b = w - 1; b <= w + 1; b++)
                    {
                        if (a <= 1 || a >= H || b <= 1 || b >= W) continue;
                        checking.Add(a + b * MOD);
                    }
                }
            }

            var result = new long[10];
            foreach (long p in checking)
            {
                var count = 0;
                var height = p % MOD;
                var width = p / MOD;
                for (long h = height - 1; h <= height + 1; h++)
                {
                    for (long w = width - 1; w <= width + 1; w++)
                    {
                        if (colored.Contains(h + w * MOD)) count++;
                    }
                }
                result[count]++;
            }

            result[0] = (H - 2) * (W - 2);
            for (int i = 1; i < 10; i++) result[0] -= result[i];
            for (int i = 0; i < 10; i++) Console.WriteLine(result[i]);
        }
    }
}
