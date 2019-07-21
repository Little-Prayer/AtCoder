using System;

namespace B___Golden_Apple
{
    class Program
    {
        static void Main(string[] args)
        {
            var ND = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine((int)Math.Ceiling((decimal)ND[0] / (decimal)(2 * ND[1] + 1)));
        }
    }
}
