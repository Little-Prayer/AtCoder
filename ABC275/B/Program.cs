using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long MOD = 998244353;
            var A = num[0] % MOD;
            var B = num[1] % MOD;
            var C = num[2] % MOD;
            var D = num[3] % MOD;
            var E = num[4] % MOD;
            var F = num[5] % MOD;
            var AB = (A * B) % MOD;
            var ABC = (AB * C) % MOD;
            var DE = (D * E) % MOD;
            var DEF = (DE * F) % MOD;
            var ABCDEF = ABC - DEF;
            if (ABCDEF < 0) ABCDEF += MOD;
            Console.WriteLine(ABCDEF);
        }
    }
}
