using System;

namespace _042___Multiple_of_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static long solver()
        {
            var K = long.Parse(Console.ReadLine());
            if (K % 9 != 0) return 0;
            long MOD = 1000000007;
            var result = new long[K + 1];
            result[0] = 1;
            for (int i = 0; i < K; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (i + j > K) break;
                    result[i + j] += result[i];
                    result[i + j] %= MOD;
                }
            }
            return result[K];
        }
    }
}
