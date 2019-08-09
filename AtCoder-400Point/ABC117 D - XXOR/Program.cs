using System;

namespace ABC117_D___XXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0];
            var K = NK[1];

            var binaryK = Convert.ToString(K, 2);
            long result = 0;
            foreach (long a in Ai)
            {
                for (int digit = binaryK.Length; digit < Convert.ToString(a, 2).Length; digit++)
                {
                    var mask = 1 << digit;
                    result += a & mask;
                }
            }
            var DP = new long[binaryK.Length + 1, 2];
            for (int digit = binaryK.Length - 1; digit >= 0; digit--)
            {
                if (K == 0) break;
                var mask = 1 << digit;
                long xorSum0 = 0;
                for (int i = 0; i < N; i++) xorSum0 += Ai[i] & mask;
                long xorSum1 = N * mask - xorSum0;
                if ((mask & K) == 0)
                {
                    DP[digit, 0] = DP[digit + 1, 0] + xorSum0;
                    DP[digit, 1] = DP[digit + 1, 1] + Math.Max(xorSum0, xorSum1);
                }
                else
                {
                    DP[digit, 0] = DP[digit + 1, 0] + xorSum1;
                    DP[digit, 1] = Math.Max(DP[digit + 1, 0] + xorSum0, DP[digit + 1, 1] + Math.Max(xorSum0, xorSum1));
                }
            }
            Console.WriteLine(Math.Max(DP[0, 0], DP[0, 1]) + result);
        }
    }
}
