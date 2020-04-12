using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine());
            var result = 0L;
            for (int a = 1; a <= K; a++)
            {
                for (int b = 1; b <= K; b++)
                {
                    for (int c = 1; c <= K; c++)
                    {
                        var ab = GCD(a, b);
                        var abc = GCD(ab, c);
                        result += abc;
                    }
                }
            }
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
