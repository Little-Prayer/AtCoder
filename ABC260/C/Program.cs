using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NXY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NXY[0]; var X = NXY[1]; var Y = NXY[2];
            long red(int level, int count)
            {
                if (level == 1) return 0;
                return red(level - 1, count) + blue(level, count * X);
            }
            long blue(int level, int count)
            {
                if (level == 1) return count;
                return red(level - 1, count) + blue(level - 1, count * Y);
            }
            Console.WriteLine(red(N, 1));
        }
    }
}
