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

            var DP = new int[numbers.Count + 1, 131072 + 1];
            DP[0, 0] = 1;
            var number = 0;
            foreach (KeyValuePair<int, int> pair in numbers)
            {
                number++;
                var key = pair.Key;
                var count = pair.Value;
                for (int i = 0; i < 100000 + 1; i++)
                {
                    if (DP[number - 1, i] == 0) continue;

                    long temp1 = DP[number - 1, i];
                    for (int j = 0; j < count - 1; j++)
                    {
                        temp1 *= 2;
                        temp1 %= MOD;
                    }
                    long temp2 = DP[number, i];
                    temp2 += temp1;
                    temp2 %= MOD;
                    DP[number, i] = (int)temp2;

                    long temp3 = DP[number, i ^ key];
                    temp3 += temp1;
                    temp3 %= MOD;
                    DP[number, i ^ key] = (int)temp3;
                }
            }
            Console.WriteLine(DP[numbers.Count, K]);
        }
    }
}
