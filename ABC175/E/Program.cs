using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var RCK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var R = RCK[0]; var C = RCK[1]; var K = RCK[2];
            var map = new long[R + 1, C + 1];
            for (int i = 0; i < K; i++)
            {
                var rcv = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                map[rcv[0], rcv[1]] = rcv[2];
            }

            var DP = new long[4, R + 2, C + 2];
            for (int c = 1; c < C + 1; c++)
            {
                for (int r = 1; r < R + 1; r++)
                {
                    for (int p = 0; p < 3; p++)
                    {
                        DP[p + 1, r, c + 1] = Math.Max(DP[p, r, c] + map[r, c], DP[p + 1, r, c + 1]);
                        DP[p, r, c + 1] = Math.Max(DP[p, r, c], DP[p, r, c + 1]);
                        DP[0, r + 1, c] = Math.Max(DP[p, r, c] + map[r, c], DP[0, r + 1, c]);
                    }
                }
            }

            Console.WriteLine(Math.Max(DP[0, R + 1, C], DP[3, R, C]));
        }
    }
}
