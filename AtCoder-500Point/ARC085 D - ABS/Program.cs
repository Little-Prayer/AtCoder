using System;

namespace ARC085_D___ABS
{
    class Program
    {
        static void Main(string[] args)
        {
            var NZW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(NZW[0] != 1 ? Math.Max(Math.Abs(Ai[Ai.Length - 1] - Ai[Ai.Length - 2]), Math.Abs(NZW[2] - Ai[Ai.Length - 1])) : Math.Abs(NZW[2] - Ai[0]));
        }
    }
}
