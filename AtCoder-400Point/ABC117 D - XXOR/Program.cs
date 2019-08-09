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
                    result += (a & mask) ^ 0;
                }
            }
            var DP = new long[binaryK.Length + 1, 2, 2];
            for (int digit = binaryK.Length - 1; digit >= 0; digit--)
            {
                if (K == 0) break;
                var mask = 1 << digit;
                long xorSum0 = 0;
                for (int i = 0; i < N; i++) xorSum0 += (Ai[i] & mask) ^ 0;
                long xorSum1 = 0;
                for (int i = 0; i < N; i++) xorSum1 += (Ai[i] & mask) ^ mask;
                DP[digit, 0, 0] = Math.Max(DP[digit + 1, 1, 0], DP[digit + 1, 0, 0]) + xorSum0;
                DP[digit, 1, 0] = Math.Max(DP[digit + 1, 1, 0], DP[digit + 1, 0, 0]) + xorSum1;
                if ((mask & K) == 0)
                {
                    DP[digit, 1, 1] = 0;
                    DP[digit, 0, 1] = Math.Max(DP[digit + 1, 0, 1], DP[digit + 1, 1, 1]) + xorSum0;
                }
                else
                {
                    DP[digit, 1, 1] = Math.Max(DP[digit + 1, 1, 1], DP[digit + 1, 0, 1]) + xorSum1;
                    DP[digit, 0, 0] = Math.Max(DP[digit, 0, 0], Math.Max(DP[digit + 1, 1, 1], DP[digit + 1, 0, 1]) + xorSum0);
                }
            }
            Console.WriteLine(Math.Max(Math.Max(DP[0, 0, 0], DP[0, 0, 1]), Math.Max(DP[0, 0, 1], DP[0, 1, 0])) + result);
        }
    }
}
