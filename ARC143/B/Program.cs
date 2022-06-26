using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            long MOD = 998244353;

            var permutation = new long[N * N + 1];
            for (long i = 1; i < N * N + 1; i++)
            {
                long result = 1;
                for (long j = 0; j < N - 1; j++)
                {
                    result *= i - j;
                    result %= MOD;
                }
                permutation[i] = result;
            }

            long all = 1;
            for (long i = 1; i <= N * N; i++)
            {
                all *= i;
                all %= MOD;
            }

            long temp = 1;
            for (int i = 1; i <= N * N - 2 * N + 1; i++)
            {
                temp *= i;
                temp %= MOD;
            }

            long allresult = 0;
            for (long i = 1; i <= N * N; i++)
            {
                long current = 1;
                current *= permutation[i - 1];
                current %= MOD;
                current *= permutation[N * N - i];
                current %= MOD;
                current *= N * N;
                current %= MOD;
                current *= temp;
                current %= MOD;
                allresult += current;
                allresult %= MOD;
            }
            allresult = all - allresult;
            if (allresult < 0) allresult += MOD;
            Console.WriteLine(N == 1 ? 0 : allresult);
        }
    }
}
