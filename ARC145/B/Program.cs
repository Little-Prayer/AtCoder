using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NAB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NAB[0]; var A = NAB[1]; var B = NAB[2];

            return N >= A ? ((N / A) - 1) * Math.Min(A, B) + Math.Min((N % A) + 1, B) : 0;
        }
    }
}
