using System;

namespace ABC117_D___XXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var DP = new long[42, 2];
            for (int digit = 40; digit >= 0; digit--)
            {
                long sum0 = 0; long sum1 = 0;
                foreach (long a in A)
                {
                    sum0 += (a & ((long)1 << digit)) ^ 0;
                    sum1 += (a & ((long)1 << digit)) ^ ((long)1 << digit);
                }
                DP[digit, 0] = DP[digit + 1, 0] > 0 ? DP[digit + 1, 0] + Math.Max(sum0, sum1) : 0;
                DP[digit, 1] = DP[digit + 1, 1] + ((K & ((long)1 << digit)) > 0 ? sum1 : sum0);
                if ((K & ((long)1 << digit)) > 0)
                {
                    DP[digit, 0] = Math.Max(DP[digit + 1, 1] + sum0, DP[digit, 0]);
                }
            }
            Console.WriteLine(Math.Max(DP[0, 0], DP[0, 1]).ToString());

        }
    }
}
