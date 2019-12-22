using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(AB[0] * AB[1] / GCD(AB[0], AB[1]));
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
