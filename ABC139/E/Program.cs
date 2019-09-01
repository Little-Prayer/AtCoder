using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            var orders = new Queue<int>[N + 1];
            for (int i = 0; i < N + 1; i++) orders[i] = new Queue<int>();
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < N - 1; j++) orders[i].Enqueue(read[j]);
            }
            var lastOrder = new int[N + 1];
            var matchCount = 0;
            var dayCount = 1;
            while (matchCount != N * (N - 1) / 2)
            {
                var canMatch = false;
                for (int i = 1; i < N + 1; i++)
                {

                }
            }
        }
    }
}
