using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static long solver()
        {
            var ABC = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = ABC[0]; var B = ABC[1]; var C = ABC[2];
            var max = Math.Max(Math.Max(A, B), C);
            var sum = A + B + C;
            if (sum - max < max) return -1;
            else return max;
        }
    }
}
