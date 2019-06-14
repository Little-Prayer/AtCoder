using System;

namespace ABC070_C___Multiple_Clocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            long result = 1;
            for (int i = 0; i < N; i++)
            {
                var T = long.Parse(Console.ReadLine());
                result = T / GCD(T, result) * result;
            }
            Console.WriteLine(result);
        }
        static long GCD(long A, long B)
        {
            if (B > A) return GCD(B, A);
            while (B != 0)
            {
                var reminder = A % B;
                A = B;
                B = reminder;
            }
            return A;
        }
    }
}
