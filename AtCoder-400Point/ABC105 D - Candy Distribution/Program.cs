using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC105_D___Candy_Distribution
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var accum = new long[N + 1];
            for (int i = 1; i < N + 1; i++) accum[i] = accum[i - 1] + Ai[i - 1];
            var modMap = new Dictionary<long, long>();
            for (int i = 0; i < N + 1; i++)
            {
                var mod = accum[i] % M;
                if (!modMap.ContainsKey(mod))
                {
                    modMap.Add(mod, 1);
                }
                else
                {
                    modMap[mod]++;
                }
            }
            long result = 0;
            foreach (int m in modMap.Keys) result += modMap[m] * (modMap[m] - 1) / 2;
            Console.WriteLine(result);
        }
    }
}
