using System;

namespace ARC064_C___Boxes_and_Candies
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NX[0];
            var X = NX[1];
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long result = 0;
            for (long i = 1; i < N; i++)
            {
                if (Ai[i] + Ai[i - 1] <= X) continue;
                long difference = Ai[i] + Ai[i - 1] - X;
                result += difference;
                Ai[i] = Math.Max(Ai[i] - difference, 0);
            }
            Console.WriteLine(result);
        }
    }
}
