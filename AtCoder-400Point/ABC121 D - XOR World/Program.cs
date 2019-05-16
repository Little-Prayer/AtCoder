using System;

namespace ABC121_D___XOR_World
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            
            var digit = 1;
            long result = 0;
            while(digit < 1000)
            {
                result += ((countBinary1(AB[1],digit)-countBinary1(AB[0]-1,digit)) % 2) * (long)Math.Pow(2,digit-1);
                digit++;
            }
            Console.WriteLine(result);
        }

        static long countBinary1(long number,int digit)
        {
            long a = (long)(number/Math.Pow(2,digit)) * (long)Math.Pow(2,digit-1);
            long b = Math.Max(number % (long)Math.Pow(2,digit) - (long)Math.Pow(2,digit-1) + 1,0);
            return a+b;
        }
    }
}
