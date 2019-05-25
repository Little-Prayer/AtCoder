using System;

namespace B___Algae
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var r = read[0];
            var D = read[1];
            var x2k = read[2];

            for(int i = 0 ; i < 10 ; i++)
            {
                x2k = r*x2k -D;
                Console.WriteLine(x2k);
            }
        }
    }
}
