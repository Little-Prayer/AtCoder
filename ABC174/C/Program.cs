using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var K = long.Parse(Console.ReadLine());
            var check = new bool[K];
            long sevens = 7;
            long result = 1;
            while (true)
            {
                if ((sevens % K) == 0) return result;
                if (check[sevens % K]) return -1;
                check[sevens % K] = true;
                sevens = (sevens * 10 + 7) % K;
                result++;
            }
        }
    }
}
