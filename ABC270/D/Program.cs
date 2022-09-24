using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();

            var getStone = new int[N + 1];
            var pickStone = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                if (A.Contains(i))
                {
                    getStone[i] = i;
                    pickStone[i] = i;
                    continue;
                }

                foreach (int g in A)
                {
                    if (i < g) continue;
                    if (getStone[i] < g + getStone[i - g - pickStone[i - g]])
                    {
                        getStone[i] = g + getStone[i - g - pickStone[i - g]];
                        pickStone[i] = g;
                    }
                }
            }
            Console.WriteLine(getStone[N]);
        }
    }
}