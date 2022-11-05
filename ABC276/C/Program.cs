using System;
using System.Collections.Generic;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var next = A[N - 1];
            var list = new List<int>();
            var top = 0;
            list.Add(next);

            for (int i = N - 2; i >= 0; i--)
            {
                if (next > A[i])
                {
                    next = A[i];
                    list.Add(A[i]);
                }
                else
                {
                    top = A[i];
                    break;
                }
            }
            var ptop = list.Where(x => x < top).Max();
            list.Add(top);
            list = list.Where(x => x != ptop).OrderByDescending(x => x).ToList();
            var result = new List<int>();
            for (int i = 0; i < N - (list.Count + 1); i++)
            {
                result.Add(A[i]);
            }
            result.Add(ptop);
            for (int i = 0; i < list.Count(); i++) result.Add(list[i]);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
