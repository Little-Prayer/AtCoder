using System;
using System.Linq;

namespace ABC057_D___Maximum_Average_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var NAB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NAB[0];
            var A = NAB[1];
            var B = NAB[2];

            var V = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Array.Sort(V);
            Array.Reverse(V);

            decimal average = 0;
            for (int i = 0; i < A; i++) average += V[i];
            average /= (decimal)A;
            Console.WriteLine(average.ToString());

            decimal pattern = 0;
            if (V[0] == V[A - 1])
            {
                var maxCount = V.Count(s => s == V[0]);
                for (int i = A; i <= Math.Min(maxCount, B); i++) pattern += conbination(maxCount, i);
            }
            else
            {
                var minCount = V.Count(s => s == V[A - 1]);
                var pickMin = A - V.Count(s => s > V[A]);
                pattern = conbination(minCount, pickMin);
            }
            Console.WriteLine(pattern);
        }

        static decimal conbination(int N, int K)
        {
            decimal result = 1;
            for (decimal d = 1; d <= K; d++) result = result * (N - d + 1) / d;
            return result;
        }
    }
}
