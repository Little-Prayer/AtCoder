using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var abx = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = abx[0]; var b = abx[1]; var x = abx[2];
            double result = Math.Atan(2 * (double)(a * a * b - x) / (double)(a * a * a)) * 180 / Math.PI;
            Console.WriteLine(result);
        }
    }
}
