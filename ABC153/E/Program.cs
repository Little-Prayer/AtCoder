using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HN[0]; var N = HN[1];
            var A = new int[N + 1];
            var B = new int[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                A[i] = ab[0]; B[i] = ab[1];
            }
            var DP = new int[N + 1, H + 1];
            for (int i = 0; i < H + 1; i++) DP[0, i] = int.MaxValue;
            for (int magic = 1; magic < N + 1; magic++)
            {
                for (int damage = 0; damage < H + 1; damage++)
                {
                    if (damage <= A[magic])
                    {
                        DP[magic, damage] = Math.Min(DP[magic - 1, damage], B[magic]);
                    }
                    else
                    {
                        DP[magic, damage] = Math.Min(DP[magic, damage - A[magic]] + B[magic], DP[magic - 1, damage]);
                    }
                }
            }
            Console.WriteLine(DP[N, H]);
        }
    }
}
