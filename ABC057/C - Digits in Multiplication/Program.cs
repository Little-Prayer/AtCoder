using System;

namespace C___Digits_in_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());

            long B = (long)Math.Sqrt(N);

            while(N % B != 0) B--;
            long A = N / B;

            int result = 0;

            while(A != 0)
            {
                A = (long)A/10;
                result++;
            }

            Console.WriteLine(result);
        }
    }
}
