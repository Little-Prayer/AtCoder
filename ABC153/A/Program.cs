using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var HA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HA[0]; var A = HA[1];
            var count = 0;
            while (H > 0)
            {
                H -= A;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
