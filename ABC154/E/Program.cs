using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            var K = int.Parse(Console.ReadLine());
            var DP = new long[N.Length + 1, K + 2, 2];
            DP[0, 0, 1] = 1;
            for (int digit = 1; digit < N.Length + 1; digit++)
            {
                var d = int.Parse(N[digit - 1].ToString());
                for (int countNot0 = 0; countNot0 < K + 1; countNot0++)
                {
                    if (d == 0)
                    {
                        DP[digit, countNot0, 1] += DP[digit - 1, countNot0, 1];
                    }
                    else
                    {
                        DP[digit, countNot0 + 1, 1] += DP[digit - 1, countNot0, 1];
                        DP[digit, countNot0, 0] += DP[digit - 1, countNot0, 1];
                        DP[digit, countNot0 + 1, 0] += DP[digit - 1, countNot0, 1] * (d - 1);
                    }
                    DP[digit, countNot0 + 1, 0] += DP[digit - 1, countNot0, 0] * 9;
                    DP[digit, countNot0, 0] += DP[digit - 1, countNot0, 0];
                }
            }
            Console.WriteLine(DP[N.Length, K, 1] + DP[N.Length, K, 0]);
        }
    }
}
