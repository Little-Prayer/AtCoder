using System;
using System.Linq;
using System.Collections.Generic;

namespace ABC136_E_Max_GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var AiSum = Ai.Sum();
            var candidates = new List<long>();
            for (long i = 1; i <= Math.Sqrt(AiSum); i++)
            {
                if (AiSum % i == 0)
                {
                    candidates.Add(i);
                    candidates.Add(AiSum / i);
                }
            }
            candidates = candidates.OrderByDescending(s => s).ToList();

            long answer = 0;
            foreach (long candidate in candidates)
            {
                var AiMod = Ai.Select(s => s % candidate).OrderByDescending(s => s).ToArray();
                var manupilationCount = AiMod.Skip((int)(AiMod.Sum() / candidate)).Sum();
                if (manupilationCount <= K)
                {
                    answer = candidate;
                    break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
