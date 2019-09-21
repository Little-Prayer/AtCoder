using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            solver();
        }
        static void solver()
        {
            var HWAB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HWAB[0]; var W = HWAB[1]; var A = HWAB[2]; var B = HWAB[3];

            var map = new bool[H, W];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    map[i, j] = ((i < B) == (j < A));
                }
            }

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Console.Write(map[i, j] ? "1" : "0");
                }
                Console.WriteLine();
            }
        }
    }
}
