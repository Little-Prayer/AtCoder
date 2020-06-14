using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static Boolean solver()
        {
            var XY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XY[0]; var Y = XY[1];
            if (Y > 4 * X) return false;
            if ((Y % 2) != 0) return false;
            if (Y < 2 * X) return false;
            return true;
        }
    }
}
