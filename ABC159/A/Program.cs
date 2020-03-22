using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            Console.WriteLine(N * (N - 1) / 2 + M * (M - 1) / 2);
        }
    }
}
