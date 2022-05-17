using System;

namespace _038___Large_LCM_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = input[0]; var B = input[1];


            var gcd = GCD(A, B);
            if (1000000000000000000 / B < A / gcd) Console.WriteLine("Large");
            else Console.WriteLine(A / gcd * B);

        }

        static long GCD(long a, long b)
        {
            if (a < b) return GCD(b, a);

            if (a % b == 0) return b;

            return GCD(b, a % b);
        }
    }
}
