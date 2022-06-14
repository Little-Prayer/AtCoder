using System;

namespace _050___Stair_Jump_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NL[0]; var L = NL[1];
            long MOD = 1000000007;
            var result = new long[N + 1];
            result[0] = 1;
            for (int i = 0; i < N; i++)
            {
                result[i + 1] += result[i];
                result[i + 1] %= MOD;
                if (i + L <= N)
                {
                    result[i + L] += result[i];
                    result[i + L] %= MOD;
                }
            }
            Console.WriteLine(result[N]);
        }
    }
}
