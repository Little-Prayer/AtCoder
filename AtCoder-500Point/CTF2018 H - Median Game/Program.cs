using System;

namespace CTF2018_H___Median_Game
{
    class Program
    {
        static int N;
        static long[] A;
        static long[] accumA;
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            accumA = new long[N + 1];
            for (int i = 1; i < N + 1; i++) accumA[i] = accumA[i - 1] + A[i - 1];

            long left = -1000000000000; long right = 1000000000000;
            while (right - left > 1)
            {
                long mid = left + (right - left) / 2;
                if (!CanMedianX(mid)) right = mid;
                else left = mid;
            }
            Console.WriteLine(left);
        }

        static bool CanMedianX(long X)
        {
            var DP = new int[N + 1, 2];
            DP[N, 0] = 0; DP[N, 1] = 0;
            for (int start = N - 1; start >= 0; start--)
            {
                DP[start, 0] = int.MinValue; DP[start, 1] = int.MaxValue;
                for (int end = start; end <= N - 1; end++)
                {
                    DP[start, 0] = Math.Max(DP[start, 0], DP[end + 1, 1] + (accumA[end + 1] - accumA[start] >= X ? 1 : -1));
                    DP[start, 1] = Math.Min(DP[start, 1], DP[end + 1, 0] + (accumA[end + 1] - accumA[start] >= X ? 1 : -1));
                }
            }
            return DP[0, 0] >= 0;
        }
    }
}
