using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var map = new bool[H, W];
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++)
                {
                    map[i, j] = (read[j] == '#');
                }
            }

            var result = new int[W];
            for (int i = 0; i < W; i++)
            {
                var count = 0;
                for (int j = 0; j < H; j++)
                {
                    if (map[j, i])
                    {
                        count++;
                    }
                }
                result[i] = count;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
