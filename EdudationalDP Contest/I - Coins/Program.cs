using System;

namespace I___Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var probs = Array.ConvertAll(Console.ReadLine().Split(' '), decimal.Parse);
            var DP = new decimal[N + 1, 2 * N + 1];
            DP[1, N + 1] = probs[0];
            DP[1, N - 1] = 1 - probs[0];

            for (int i = 1; i < N; i++)
            {
                for (int j = N - i; j <= N + i; j++)
                {
                    DP[i + 1, j + 1] += DP[i, j] * probs[i];
                    DP[i + 1, j - 1] += DP[i, j] * (1 - probs[i]);
                }
            }
            decimal result = 0;
            for (int i = N; i <= 2 * N; i++) result += DP[N, i];

            Console.WriteLine(result);
        }
    }
}
