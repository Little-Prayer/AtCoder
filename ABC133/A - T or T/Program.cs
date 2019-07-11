using System;

namespace A___T_or_T
{
    class Program
    {
        static void Main(string[] args)
        {
            var NAB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NAB[0];
            var A = NAB[1];
            var B = NAB[2];

            Console.WriteLine(Math.Min(N * A, B));
        }
    }
}
