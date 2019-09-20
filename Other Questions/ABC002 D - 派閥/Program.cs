using System;
using System.Collections.Generic;

namespace ABC002_D___派閥
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var connection = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connection[i] = new List<int>();
            for (int i = 0; i < M; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[xy[0]].Add(xy[1]);
                connection[xy[1]].Add(xy[0]);
            }

            var result = 1;
            for (int i = 1; i < (1 << N); i++)
            {
                var group = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    if ((i & (1 << j)) > 0) group.Add(j + 1);
                }
                if (group.Count == 1) continue;

                var isFaction = true;
                for (int m = 0; m < group.Count; m++)
                {
                    for (int n = m + 1; n < group.Count; n++)
                    {
                        if (connection[group[m]].Contains(group[n]) && connection[group[n]].Contains(group[m])) continue;
                        isFaction = false;
                        break;
                    }
                    if (!isFaction) break;
                }
                if (isFaction) result = Math.Max(result, group.Count);
            }

            Console.WriteLine(result);
        }
    }
}
