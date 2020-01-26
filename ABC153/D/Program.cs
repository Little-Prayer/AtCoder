using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var H = long.Parse(Console.ReadLine());
            Console.WriteLine(solver(H));
        }
        static long solver(long h)
        {
            if (h == 1) return 1;
            else return solver(h / 2) * 2 + 1;
        }
    }
}
