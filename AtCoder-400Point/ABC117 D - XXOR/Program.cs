using System;

namespace ABC117_D___XXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var binaryK = Convert.ToString(NK[1], 2);
            var sumXOR = new long[binaryK.Length, 2];
            for (int digit = 0; digit < binaryK.Length; digit++)
            {

            }
        }
    }
}
