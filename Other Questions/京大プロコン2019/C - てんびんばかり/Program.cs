using System;

namespace C___てんびんばかり
{
    class Program
    {
        static void Main(string[] args)
        {
            var MK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var M = MK[0]; var K = MK[1];
            var count = 1;
            long max = K;
            while (max < M)
            {
                count++;
                max = (2 * max + 1) * K + max;
            }
            Console.WriteLine(count);
        }
    }
}
