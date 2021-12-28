using System;
using static System.Math;
using System.Linq;

namespace _036___Max_Manhattan_Distance_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var map = new long[NQ[0], 2];
            var maxX = long.MinValue;
            var minX = long.MaxValue;
            var maxY = long.MinValue;
            var minY = long.MaxValue;
            for (long i = 0; i < NQ[0]; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                map[i, 0] = xy[0] - xy[1];
                map[i, 1] = xy[0] + xy[1];
                maxX = Max(maxX, map[i, 0]);
                maxY = Max(maxY, map[i, 1]);
                minX = Min(minX, map[i, 0]);
                minY = Min(minY, map[i, 1]);
            }
            for (long i = 0; i < NQ[1]; i++)
            {
                var q = long.Parse(Console.ReadLine());
                Console.WriteLine(new long[] { maxX - map[q - 1, 0], map[q - 1, 0] - minX, maxY - map[q - 1, 1], map[q - 1, 1] - minY }.Max());
            }
        }
    }
}
