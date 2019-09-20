using System;
using System.Collections.Generic;

namespace CTF2017_F___Limited_Xor_Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            long MOD = 1000000007;
            var numbers = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                var a = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(a)) numbers[a]++;
                else numbers.Add(a, 1);
            }

            var DP = new long[numbers.Count + 1, 100000 + 1];
            DP[0, 0] = 1;
            var number = 0;
            foreach (KeyValuePair<int, int> pair in numbers)
            {
                number++;
                var key = pair.Key;
                var count = pair.Value;
                for (int i = 0; i < 100000 + 1; i++)
                {
                    DP[number, i] += DP[number - 1, i] * (count / 2 + 1);
                    DP[number, i] %= MOD;

                    DP[number, i % key] += DP[number - 1, i] * (count + 1) / 2;
                    DP[number, i % key] %= MOD;
                }
            }
            Console.WriteLine(DP[numbers.Count, K]);
        }
    }
}
