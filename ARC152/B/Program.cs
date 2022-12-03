using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var NL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NL[0]; var L = NL[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var left = A[0] * 2;
            var right = (L - A[N - 1]) * 2;
            if (left == right) return L * 2;

        }
    }
}
