using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            Console.WriteLine(N * (N - 1) / 2);
        }
    }
}