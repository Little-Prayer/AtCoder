using System;

namespace ABC054_C___One_Stroke_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];

            var joint = new bool[N, N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) joint[i, j] = false;
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                joint[ab[0] - 1, ab[1] - 1] = true;
                joint[ab[1] - 1, ab[0] - 1] = true;
            }

            var dp = new int[1 << N, N];
            for (int i = 0; i < dp.GetLength(0); i++) for (int j = 0; j < dp.GetLength(1); j++) dp[i, j] = 0;
            for (int i = 0; i < N; i++) dp[1 << i, i] = 1;

            for (int bit = 1; bit < dp.GetLength(0); bit++)
                for (int last = 0; last < dp.GetLength(1); last++)
                {
                    if ((bit & (1 << last)) == 0) continue;
                    for (int prev = 0; prev < dp.GetLength(1); prev++)
                    {
                        if (((bit - (1 << last)) & (1 << prev)) > 0)
                            if (joint[last, prev])
                                dp[bit, last] += dp[bit - (1 << last), prev];
                    }
                }

            Console.WriteLine(dp[dp.GetLength(0) - 1, 0]);


        }
    }
}
