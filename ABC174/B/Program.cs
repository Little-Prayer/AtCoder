using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ND = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = ND[0];
            var D = ND[1];

            var count = 0;
            for (int i = 0; i < N; i++)
            {
                var XY = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                if (XY[0] * XY[0] + XY[1] * XY[1] <= D * D) count++;
            }
            Console.WriteLine(count);
        }
    }
}
