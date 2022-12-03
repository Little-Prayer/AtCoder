using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var arr = new List<(long turn, long add)>[N + 1];
            var currentAdd = 0L;
            var currentQ = -1L;
            for (int i = 0; i < N; i++)
            {
                arr[i + 1] = new List<(long, long)>();
                arr[i + 1].Add((0, A[i]));
            }
            var Q = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Q; i++)
            {
                var query = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                if (query[0] == 1)
                {
                    currentAdd = query[1];
                    currentQ = i;
                }
                if (query[0] == 2)
                {
                    arr[query[1]].Add((i, query[2]));
                }
                if (query[0] == 3)
                {
                    var result = currentAdd;
                    foreach (var c in arr[query[1]])
                    {
                        if (currentQ < c.turn) result += c.add;
                    }
                    Console.WriteLine(result);
                    arr[query[1]].Clear();
                    arr[query[1]].Add((i, result - currentAdd));
                }
            }
        }
    }
}
