using System;
using System.Linq;

namespace ABC100_D___Patisserie_ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];
            var cakes = new long[N, 3];
            for (int i = 0; i < N; i++)
            {
                var xyz = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                cakes[i, 0] = xyz[0];
                cakes[i, 1] = xyz[1];
                cakes[i, 2] = xyz[2];
            }

            long maxPoint = 0;
            for (int bit = 0; bit < (1 << 3); bit++)
            {
                var signX = (bit & (1 << 0)) > 0 ? -1 : 1;
                var signY = (bit & (1 << 1)) > 0 ? -1 : 1;
                var signZ = (bit & (1 << 2)) > 0 ? -1 : 1;

                var cakesTotal = new long[N];
                for (int i = 0; i < N; i++)
                    cakesTotal[i] = cakes[i, 0] * signX + cakes[i, 1] * signY + cakes[i, 2] * signZ;

                var totalPoint = cakesTotal.OrderByDescending(s => s).Take(M).Sum();
                maxPoint = Math.Max(maxPoint, totalPoint);
            }

            Console.WriteLine(maxPoint);
        }
    }
}
