using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var xkd = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var X = xkd[0]; var K = xkd[1]; var D = xkd[2];

            if (X < 0) X = X * -1;

            if (X / D > K) return X - K * D;

            var min = X % D;

            if (((K - X / D) % 2) == 0) return min;
            else return D - min;
        }
    }
}
