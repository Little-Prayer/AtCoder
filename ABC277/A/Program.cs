using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = 0;
            for (int i = 0; i < N; i++)
            {
                if (X == P[i]) result = i + 1;
            }
            Console.WriteLine(result);
        }
    }
}
