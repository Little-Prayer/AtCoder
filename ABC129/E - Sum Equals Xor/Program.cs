using System;

namespace E___Sum_Equals_Xor
{
    class Program
    {
        static void Main(string[] args)
        {
            var L = Console.ReadLine();
            var dp = new long[L.Length + 1, 2];
            dp[0, 1] = 1;
            long MOD = 1000000007;

            for (int i = 1; i < L.Length + 1; i++)
            {
                dp[i, 0] += (dp[i - 1, 0] * 3) % MOD;

                if (L[i - 1] == '1')
                {
                    dp[i, 1] += (dp[i - 1, 1] * 2) % MOD;
                    dp[i, 0] += (dp[i - 1, 1]) % MOD;
                }
                else
                {
                    dp[i, 1] += dp[i - 1, 1] % MOD;
                }
            }
            var result = (dp[L.Length, 0] + dp[L.Length, 1]) % MOD;
            Console.WriteLine(result);
        }
    }
}
