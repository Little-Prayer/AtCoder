using System;

namespace C___Remainder_Minimization_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var LR = Array.ConvertAll(Console.ReadLine().Split(' '), ulong.Parse);
            var L = LR[0];
            var R = LR[1];

            ulong result;

            if (L / 673 == R / 673)
            {
                result = (L * (L + 1)) % 2019;
            }
            else
            {
                result = 0;
            }
            Console.WriteLine(result);
        }
    }
}
