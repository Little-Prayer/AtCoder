using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKD = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NKD[0]; var K = NKD[1]; var D = NKD[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var DP = new long[N + 1, K + 1, D];
            for (int i = 0; i <= N; i++) for (int j = 0; j < D; j++) for (int h = 0; h <= K; h++) DP[i, h, j] = long.MinValue;
            for (int i = 0; i <= N; i++) DP[i, 0, 0] = 0;

            for (int num = 1; num <= N; num++)
            {
                for (int take = 0; take < K; take++)
                {
                    for (int m = 0; m < D; m++)
                    {

                        DP[num, take + 1, (m + A[num - 1]) % D] = Math.Max(DP[num - 1, take, m] + A[num - 1], DP[num - 1, take + 1, (m + A[num - 1]) % D]);

                    }
                }
            }
            Console.WriteLine(DP[N, K, 0] >= 0 ? DP[N, K, 0] : -1);
        }
    }
}
