using System;

namespace D___Digits_Parade
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var N = new int[S.Length];
            for (int i = 0; i < S.Length; i++) N[i] = S[i] == '?' ? -1 : int.Parse(S[i].ToString());
            var MOD = 1000000007;
            var DP = new long[13, S.Length + 1];
            DP[0, 0] = 1;

            for (int i = 0; i < N.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (N[i] != -1 && N[i] != j) continue;
                    for (int k = 0; k < 13; k++)
                    {
                        DP[(10 * k + j) % 13, i + 1] += DP[k, i];
                        DP[(10 * k + j) % 13, i + 1] %= MOD;
                    }
                }
            }
            Console.WriteLine(DP[5, S.Length]);
        }
    }
}
