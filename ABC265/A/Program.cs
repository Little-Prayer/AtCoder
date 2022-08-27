using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var XYN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XYN[0]; var Y = XYN[1]; var N = XYN[2];

            var cy = N / 3;
            var cx = N % 3;
            Console.WriteLine(Math.Min(X * N, cy * Y + cx * X));
        }
    }
}
