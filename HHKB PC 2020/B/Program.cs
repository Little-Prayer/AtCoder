using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var map = new bool[W + 1, H + 1];
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++)
                {
                    map[j, i] = read[j] == '.';
                }
            }

            var result = 0;
            for (int h = 0; h < H; h++)
            {
                for (int w = 0; w < W; w++)
                {
                    if (map[w, h])
                    {
                        if (map[w + 1, h]) result++;
                        if (map[w, h + 1]) result++;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
