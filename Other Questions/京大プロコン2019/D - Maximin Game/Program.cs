using System;

namespace D___Maximin_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var MOD = 998244353;

            var DP = new long[N + 1, 2 * N + 1];
            DP[1, 1] = 1;
            for (int i = 2; i < N; i++)
            {
                for (int j = i; j <= 2 * i - 1; j++)
                {
                    for (int k = 1; k < j; k++)
                    {
                        DP[i, j] += DP[i - 1, k];
                        DP[i, j] %= MOD;
                    }
                }
            }
            var p3 = new long[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < 2 * N + 1; j++)
                {
                    p3[i] += DP[i, j];
                    p3[i] %= MOD;
                }
            }

            var result = 1L;
            var count = 1;
            for (int i = 1; i < N; i++)
            {
                if (S[i] == S[i - 1])
                {
                    count++;
                }
                else
                {
                    result *= p3[count];
                    result %= MOD;
                    count = 1;
                }
            }
            result *= p3[count];
            result %= MOD;

            Console.WriteLine(result);
        }
    }
}
