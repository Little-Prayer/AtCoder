using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HWK[0]; var W = HWK[1]; var K = HWK[2];
            var map = new bool[H, W];

            for (int h = 0; h < H; h++)
            {
                var read = Console.ReadLine();
                for (int w = 0; w < W; w++) map[h, w] = read[w] == '#';
            }

            var result = 0;
            for (int hlines = 0; hlines < (1 << H); hlines++)
            {
                for (int wlines = 0; wlines < (1 << W); wlines++)
                {
                    var copyMap = new bool[H, W];
                    Array.Copy(map, copyMap, map.Length);
                    for (int delH = 0; delH < H; delH++)
                    {
                        if ((hlines & (1 << delH)) > 0)
                        {
                            for (int w = 0; w < W; w++)
                            {
                                copyMap[delH, w] = false;
                            }
                        }
                    }
                    for (int delW = 0; delW < W; delW++)
                    {
                        if ((wlines & (1 << delW)) > 0)
                        {
                            for (int h = 0; h < H; h++)
                            {
                                copyMap[h, delW] = false;
                            }
                        }
                    }

                    var count = 0;
                    for (int h = 0; h < H; h++)
                    {
                        for (int w = 0; w < W; w++)
                        {
                            if (copyMap[h, w]) count++;
                        }
                    }
                    if (count == K) result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
