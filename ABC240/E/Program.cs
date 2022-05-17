using System;
using System.Collections.Generic;
namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());
            for (int test = 0; test < T; test++)
            {
                var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var N = NM[0]; var M = NM[1];
                var xy = new long[N, 2];
                for (int i = 0; i < N; i++)
                {
                    var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                    xy[i, 0] = xy[0]; xy[i, 1] = xy[1];
                }
                long accel = 0;
                long max = xy[0, 0];
                long current = 0;
                for (int i = 0; i < N; i++)
                {
                    if (xy[i, 0] >)
                }
            }
        }
    }
}
