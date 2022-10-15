using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var oddA = A.Where(x => (x % 2) == 1).ToArray();
            var maxOddSum = 0;
            if (oddA.Length >= 2) maxOddSum = oddA.OrderByDescending(x => x).Take(2).Sum();

            var evenA = A.Where(x => (x % 2) == 0).ToArray();
            var maxEvenSum = 0;
            if (evenA.Length >= 2) maxEvenSum = evenA.OrderByDescending(x => x).Take(2).Sum();

            if (maxEvenSum > 0 || maxOddSum > 0)
            {
                Console.WriteLine(Math.Max(maxEvenSum, maxOddSum));
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}
