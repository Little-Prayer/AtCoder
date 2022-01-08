using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = new Stack<int>();
            var check = new bool[N + 1];
            for (int i = 0; i < N + 1; i++) check[i] = true;
            var current = N - K + 1;
            for (int i = N; i >= K; i--)
            {
                result.Push(current);
                check[P[i - 1]] = false;
                if (P[i - 1] >= current)
                {
                    current--;
                    while (!check[current]) current--;
                }
            }
            while (result.Count > 0) Console.WriteLine(result.Pop());
        }
    }
}
