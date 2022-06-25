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
            var isAdult = Console.ReadLine().Select(c => c == '1').ToArray();
            var W = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).ToList();
            var adult = new List<int>();
            var child = new List<int>();
            for (int i = 0; i < N; i++) if (isAdult[i]) adult.Add(W[i]);
                else child.Add(W[i]);
            adult = adult.OrderByDescending(n => n).ToList();
            child = child.OrderBy(n => n).ToList();

            W.Add(0);
            W.Add(1000000000);
            var result = 0;
            for (int i = 0; i < W.Count; i++)
            {
                var currentChild = lower_bound(child.Count, -1, c => child[c] < W[i]);
                var currentAdult = lower_bound(adult.Count, -1, a => adult[a] >= W[i]);
                result = Math.Max(currentChild + currentAdult + 2, result);
            }
            Console.WriteLine(result);
        }

        static int lower_bound(int ng, int ok, Func<int, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                int mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }
}
