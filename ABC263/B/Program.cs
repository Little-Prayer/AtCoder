using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var current = N - 2;
            var count = 0;
            while (current >= 0)
            {
                current = P[current] - 2;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
