using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            var DP = new long[N.Length + 1, 2];
            DP[N.Length, 1] = 10;
            for (int i = N.Length - 1; i >= 0; i--)
            {
                var d = int.Parse(N[i].ToString());
                DP[i, 0] = Math.Min(DP[i + 1, 0] + d, DP[i + 1, 1] + d + 1);
                DP[i, 1] = Math.Min(DP[i + 1, 0] + (10 - d), DP[i + 1, 1] + (10 - (d + 1)));
            }
            Console.WriteLine(Math.Min(DP[0, 0], DP[0, 1] + 1));
        }
    }
}
