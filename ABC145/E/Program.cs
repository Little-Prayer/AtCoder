using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NT = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NT[0]; var T = NT[1];
            var A = new int[N + 1]; var B = new int[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                A[i] = AB[0]; B[i] = AB[1];
            }

            var DP = new int[N + 1, T, 2];
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < T; j++)
                {
                    if (j >= A[i])
                    {
                        DP[i, j, 0] = Math.Max(DP[i - 1, j - A[i], 0] + B[i], DP[i - 1, j, 0]);
                        DP[i, j, 1] = Math.Max(DP[i - 1, j - A[i], 1] + B[i], DP[i - 1, j, 1]);
                    }
                    else
                    {
                        DP[i, j, 0] = DP[i - 1, j, 0];
                        DP[i, j, 1] = DP[i - 1, j, 1];
                    }

                    DP[i, j, 1] = Math.Max(DP[i - 1, j, 0] + B[i], DP[i, j, 1]);
                }
            }
            Console.WriteLine(DP[N, T - 1, 1]);
        }
    }
}
