using System;

namespace C___Digits_in_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());

            int divisor = Math.Sqrt(N);

            while(N % divisor == 0) divisor--;
            
        }
    }
}
