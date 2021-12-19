using System;

namespace _010___Score_Sum_Queries_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var accumlator1 = new int[N + 1];
            var accumlator2 = new int[N + 1];

            for (int i = 1; i < N + 1; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (read[0] == 1)
                {
                    accumlator1[i] = accumlator1[i - 1] + read[1];
                    accumlator2[i] = accumlator2[i - 1];
                }
                else
                {
                    accumlator1[i] = accumlator1[i - 1];
                    accumlator2[i] = accumlator2[i - 1] + read[1];
                }
            }

            var Q = int.Parse(Console.ReadLine());

            for (int i = 0; i < Q; i++)
            {
                var lr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var answer1 = accumlator1[lr[1]] - accumlator1[lr[0] - 1];
                var answer2 = accumlator2[lr[1]] - accumlator2[lr[0] - 1];
                Console.WriteLine($"{answer1} {answer2}");
            }
        }
    }
}
