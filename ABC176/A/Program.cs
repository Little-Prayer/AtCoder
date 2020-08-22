using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NXT = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NXT[0]; var X = NXT[1]; var T = NXT[2];

            Console.WriteLine(((N + X - 1) / X) * T);
        }
    }
}
