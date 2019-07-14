using System;
using System.Linq;

namespace A___XOR_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var all0 = true;
            for (int i = 0; i < N; i++)
            {
                if (Ai[i] != 0)
                {
                    all0 = false;
                    break;
                }
            }
            if (all0) return true;

            if (N % 3 != 0) return false;

            var distAi = Ai.Distinct().ToArray();
            if (distAi.Length == 3)
            {
                if (Ai.Count(s => s == distAi[0]) == Ai.Count(s => s == distAi[1]))
                    if (Ai.Count(s => s == distAi[1]) == Ai.Count(s => s == distAi[2]))
                        if ((distAi[0] ^ distAi[1]) == distAi[2])
                            return true;
            }
            if (distAi.Length == 2)
            {
                if (Ai.Count(s => s == 0) == N / 3) return true;
            }

            return false;
        }
    }
}
