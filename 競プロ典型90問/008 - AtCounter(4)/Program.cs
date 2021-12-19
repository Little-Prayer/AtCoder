using System;

namespace _008___AtCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var result = new long[7];
            long MOD = 1000000007;

            foreach (char s in S)
            {
                if (s == 'a') result[0] = (result[0] + 1) % MOD;
                if (s == 't') result[1] = (result[1] + result[0]) % MOD;
                if (s == 'c') result[2] = (result[2] + result[1]) % MOD;
                if (s == 'o') result[3] = (result[3] + result[2]) % MOD;
                if (s == 'd') result[4] = (result[4] + result[3]) % MOD;
                if (s == 'e') result[5] = (result[5] + result[4]) % MOD;
                if (s == 'r') result[6] = (result[6] + result[5]) % MOD;
            }
            Console.WriteLine(result[6]);
        }
    }
}
