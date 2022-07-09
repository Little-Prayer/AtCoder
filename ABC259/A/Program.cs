using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = input[0]; var M = input[1]; var X = input[2]; var T = input[3]; var D = input[4];
            var tall = new int[101];
            for (int i = N; i <= 100; i++) tall[i] = T;
            for (int i = N - 1; i >= 0; i--)
            {
                if (i >= X) tall[i] = tall[i + 1];
                else tall[i] = tall[i + 1] - D;
            }
            Console.WriteLine(tall[M]);
        }
    }
}
