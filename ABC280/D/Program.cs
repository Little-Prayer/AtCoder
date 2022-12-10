using System;
using System.Collections.Generic;
using System.Linq;
namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = long.Parse(Console.ReadLine());
            var pf = new Dictionary<long, long>();
            long p = 2;
            while (p * p <= K)
            {
                if ((K % p) == 0)
                {
                    if (pf.ContainsKey(p))
                    {
                        pf[p]++;
                    }
                    else
                    {
                        pf.Add(p, 1);
                    }
                    K /= p;
                }
                else
                {
                    p++;
                }
            }
            if (pf.ContainsKey(K))
            {
                pf[K]++;
            }
            else
            {
                pf.Add(K, 1);
            }

            var pc = new List<long>();
            foreach (var prime in pf.Keys)
            {
                var count = 0;
                for (long i = 1; ; i++)
                {
                    count++;
                    var temp = i;
                    while ((temp % prime) == 0)
                    {
                        count++;
                        temp /= prime;
                    }
                    if (count >= pf[prime])
                    {
                        pc.Add(prime * i);
                        break;
                    }
                }
            }
            Console.WriteLine(pc.Max());
        }
    }
}
