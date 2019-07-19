using System;
using System.Linq;
using System.Collections.Generic;

namespace ABC099_D___Good_Grid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var NC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (NC[0] == 1) return 0;

            var paintingCost = new int[NC[1] + 1, NC[1] + 1];
            for (int after = 0; after < NC[1]; after++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int before = 0; before < NC[1]; before++) paintingCost[after + 1, before + 1] = read[before];
            }

            var gridGroup = new List<int>[3];
            for (int i = 0; i < 3; i++) gridGroup[i] = new List<int>();

            for (int cy = 0; cy < NC[0]; cy++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int cx = 0; cx < NC[0]; cx++) gridGroup[(cx + cy + 2) % 3].Add(read[cx]);
            }

            var paintAllCost = new int[NC[1] + 1, 3];
            for (int group = 0; group < 3; group++)
            {
                for (int color = 1; color <= NC[1]; color++)
                {
                    paintAllCost[color, group] = 0;
                    foreach (int grid in gridGroup[group]) paintAllCost[color, group] += paintingCost[grid, color];
                }
            }

            var result = int.MaxValue;
            for (int color0 = 1; color0 <= NC[1]; color0++)
            {
                for (int color1 = 1; color1 <= NC[1]; color1++)
                {
                    if (color1 == color0) continue;
                    for (int color2 = 1; color2 <= NC[1]; color2++)
                    {
                        if (color0 == color2 || color1 == color2) continue;
                        result = Math.Min(result, paintAllCost[color0, 0] + paintAllCost[color1, 1] + paintAllCost[color2, 2]);
                    }
                }
            }
            return result;
        }
    }
}
