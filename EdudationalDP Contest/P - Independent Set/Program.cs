using System;
using System.Collections.Generic;

namespace P___Independent_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var connection = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connection[i] = new List<int>();

            for (int i = 0; i < N; i++)
            {
                var edge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[edge[0]].Add(edge[1]);
                connection[edge[1]].Add(edge[0]);
            }
        }
    }
}
