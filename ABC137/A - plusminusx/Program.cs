using System;

namespace A___plusminusx
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(Math.Max(ab[0] + ab[1], Math.Max(ab[0] - ab[1], ab[0] * ab[1])));
        }
    }
}
