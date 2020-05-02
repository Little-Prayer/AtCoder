using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABN = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = ABN[0]; var B = ABN[1]; var N = ABN[2];
            if (B - 1 <= N) Console.WriteLine(calc(B - 1, A, B));
            else Console.WriteLine(calc(N, A, B));
        }

        static long calc(long x, long A, long B)
        {
            return ((A * x) / B) - A * (x / B);
        }
    }
}
