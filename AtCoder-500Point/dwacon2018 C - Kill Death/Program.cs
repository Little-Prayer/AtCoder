using System;
using System.Collections.Generic;
using System.Linq;

namespace dwacon2018_C___Kill_Death
{
    class Program
    {
        static long[,] splitNumber;
        static long MOD;
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            MOD = 1000000007;


            splitNumber = new long[1000 + 1, 100 + 1];
            splitNumber[0, 1] = 1;
            for (int n = 0; n < 1000 + 1; n++)
            {
                for (int s = 1; s < 100 + 1; s++)
                {
                    if (s + 1 < 100 + 1)
                    {
                        splitNumber[n, s + 1] += splitNumber[n, s];
                        splitNumber[n, s + 1] %= MOD;
                    }
                    if (n + s < 1000 + 1)
                    {
                        splitNumber[n + s, s] += splitNumber[n, s];
                        splitNumber[n + s, s] %= MOD;
                    }
                }
            }

            var killA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var deathBSum = killA.Sum();
            var killB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var deathASum = killB.Sum();

            Console.WriteLine(DeathCalc(killA, deathASum) * DeathCalc(killB, deathBSum) % MOD);

        }
        static long DeathCalc(int[] kill, int totalDeath)
        {
            var group = new List<int>();
            var count = 1;
            for (int i = 0; i < kill.Length - 1; i++)
            {
                if (kill[i] == kill[i + 1])
                {
                    count++;
                }
                else
                {
                    group.Add(count);
                    count = 1;
                }
            }
            group.Add(count);

            var DP = new long[group.Count + 1, totalDeath + 1];
            DP[0, 0] = 1;
            for (int g = 1; g < group.Count + 1; g++)
            {
                for (int td = 0; td < totalDeath + 1; td++)
                {
                    for (int d = 0; d <= td; d++)
                    {
                        DP[g, td] += DP[g - 1, td - d] * splitNumber[d, group[g - 1]];
                        DP[g, td] %= MOD;
                    }
                }
            }
            return DP[group.Count, totalDeath];
        }
    }
}
