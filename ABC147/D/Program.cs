using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var result = 0L;
            long MOD = 1000000007;
            for (int d = 0; d < 60; d++)
            {
                var count = 0L;
                for (int i = 0; i < N; i++)
                {
                    if ((A[i] & (1L << d)) > 0) count++;
                }
                long sub = count * (N - count);
                sub %= MOD;
                long sub2 = (1L << d) % MOD;
                result += sub2 * sub;
                result %= MOD;
            }
            Console.WriteLine(result);
        }
    }
}
