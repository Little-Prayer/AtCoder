using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWNhw = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Height = HWNhw[0]; var Width = HWNhw[1]; var N = HWNhw[2]; var he = HWNhw[3]; var wid = HWNhw[4];
            var map = new int[Height + 1, Width + 1];
            for (int i = 1; i < Height + 1; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < Width; j++) { map[i, j + 1] = read[j]; }
            }
            var accumV = new int[Height + 1, Width + 1, N + 1];
            var accumH = new int[Height + 1, Width + 1, N + 1];
            var ALL = new int[N + 1];
            for (int h = 1; h <= Height; h++)
            {
                for (int w = 1; w <= Width; w++)
                {
                    accumV[h, w, map[h, w]] = accumV[h - 1, w, map[h, w]] + 1;
                    accumH[h, w, map[h, w]] = accumH[h, w - 1, map[h, w]] + 1;
                    ALL[map[h, w]]++;
                }
            }

            var area = new int[Height + 1, Width + 1, N + 1];
            for (int h = 0; h + he <= Height; h++)
            {
                for (int w = 0; w + wid <= Width; w++)
                {
                    for (int num = 1; num <= N; num++)
                    {
                        for (int high = h; high <= h + he; high++)
                        {
                            area[h, w, num] += accumV[high, w + wid, num] - accumV[high, w, num];
                        }
                    }
                }
            }
            var result = new int[Height + 1, Width + 1];
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    var current = 0;
                    for (int num = 1; num <= N; num++)
                    {
                        if (ALL[num] > area[h, w, num]) current++;
                    }
                    result[h, w] = current;
                }
            }
            for (int h = 0; h < Height; h++) for (int w = 0; w < Width; w++) Console.WriteLine(result[h, w]);
        }
    }
}
