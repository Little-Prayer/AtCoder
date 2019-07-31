using System;
using System.Collections.Generic;

namespace ARC060_D___桁和__Digit_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long digitSum(long b, long n)
        {
            long result = 0;
            while (b <= n)
            {
                result += (n % b);
                n = n / b;
            }
            result += n;
            return result;
        }
        static long solver()
        {
            var N = long.Parse(Console.ReadLine());
            var S = long.Parse(Console.ReadLine());
            if (N == S) return N + 1;
            var sqrtN = (long)Math.Sqrt(N);
            for (long i = 2; i <= sqrtN; i++) if (digitSum(i, N) == S) return i;
            var divisorNS = new List<long>();
            for (long i = (long)Math.Sqrt(N - S); i >= 1; i--) if (((N - S) % i) == 0) divisorNS.Add((N - S) / i);
            foreach (long b in divisorNS) if (digitSum(b + 1, N) == S) return b + 1;
            return -1;
        }
    }
}
