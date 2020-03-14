using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var abc = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var a = abc[0]; var b = abc[1]; var c = abc[2];
            if (a + b > c) return false;
            return (c - (a + b)) * (c - (a + b)) > 4 * a * b;
        }
    }
}
