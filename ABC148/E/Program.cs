using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = long.Parse(Console.ReadLine());
            if ((N % 2) == 1) return 0;
            var result = 0L;
            var temp2 = 10L;
            result += N / 10;
            for (int i = 1; i <= 36; i++)
            {
                temp2 *= 5;
                result += N / temp2;
            }
            return result;
        }
    }
}
