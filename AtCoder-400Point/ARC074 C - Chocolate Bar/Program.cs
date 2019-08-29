using System;

namespace ARC074_C___Chocolate_Bar
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HW[0];
            var W = HW[1];

            var S = long.MaxValue;
            for (int h = 1; h < H; h++)
            {
                var s1 = h * W;
            }
        }
    }
}
