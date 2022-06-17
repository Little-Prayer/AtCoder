using System;
using System.Collections.Generic;
using System.Linq;

namespace _051___Typical_Shop_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKP = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NKP[0]; var K = NKP[1]; var P = NKP[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var first = powerset(A.Take(N / 2)).ToList();
            var second = powerset(A.Skip(N / 2)).ToList();
            var subtotal = new List<long>[K + 1];
            for (int i = 0; i <= K; i++) subtotal[i] = new List<long>();
            foreach (var s in second)
            {
                var current = s.ToList();
                if (current.Count() <= K)
                {
                    subtotal[current.Count()].Add(current.Sum());
                }
            }
            for (int i = 0; i <= K; i++) subtotal[i] = subtotal[i].OrderBy(n => n).ToList();

            long result = 0;
            foreach (var c in first)
            {
                var current = c.ToList();
                if (current.Count <= K)
                {
                    result += lower_bound(subtotal[K - current.Count()].Count(), -1, n => subtotal[K - current.Count()][(int)n] + current.Sum() <= P) + 1;
                }
            }
            Console.WriteLine(result);
        }


        static IEnumerable<IEnumerable<T>> powerset<T>(IEnumerable<T> e)
        {
            var s = e.ToList();
            var n = s.Count;
            var N = 1 << n;
            return Enumerable.Range(0, N).Select(m =>
                    Enumerable.Range(0, n).Where(i => (m & 1 << i) != 0)
                    .Select(i => s.ElementAt(i)));
        }
        static long lower_bound(long ng, long ok, Func<long, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                long mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }

}

