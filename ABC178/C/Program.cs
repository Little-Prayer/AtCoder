using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            long MOD = 1000000007;

            long a10 = 1;
            long a9 = 1;
            long a8 = 1;

            for (int i = 0; i < N; i++)
            {
                a10 *= 10;
                a10 %= MOD;
                a9 *= 9;
                a9 %= MOD;
                a8 *= 8;
                a8 %= MOD;
            }
            long result = a10 - 2 * a9 + a8;
            result %= MOD;
            if (result < 0) result += MOD;
            Console.WriteLine(result);
        }
    }
}
