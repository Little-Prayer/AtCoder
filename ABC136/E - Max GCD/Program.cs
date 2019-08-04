using System;
using System.Linq;
using System.Collections.Generic;

namespace E___Max_GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long AiSum = Ai.Sum();
            var AiDev = new List<long>();
            for (int i = 2; i <= Math.Sqrt(AiSum); i++) if (AiSum % i == 0) AiDev.Add(i);
            AiDev = AiDev.OrderByDescending(s => s);
            Console.WriteLine(solver(Ai, AiDev));
        }
        static long solver(long[] Ai, long[] AiDev)
        {
            foreach (long l in AiDev)
            {
                var distance = new long[Ai.Length];
                for (int i = 0; i < Ai.Length; i++)
                {

                }
            }

        }
    }
}
