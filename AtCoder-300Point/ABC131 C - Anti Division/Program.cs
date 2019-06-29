using System;

namespace ABC131_C___Anti_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = read[0];
            var B = read[1];
            var C = read[2];
            var D = read[3];
            var lcmCD = C * D / GCD(C, D);
            long result = (B - A + 1) - (B / C - (A - 1) / C) - (B / D - (A - 1) / D) + (B / lcmCD - (A - 1) / lcmCD);

            Console.WriteLine(result);




        }

        static long GCD(long A, long B)
        {
            if (B > A) return GCD(B, A);
            if (A % B == 0)
            {
                return B;
            }
            else
            {
                return GCD(B, A % B);
            }
        }
    }
}
