using System;
using System.Collections.Generic;
namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0]; var Q = NQ[1];
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < N; i++)
            {
                if (!dic.ContainsKey(a[i]))
                {
                    var item = new List<int>();
                    item.Add(i + 1);
                    dic.Add(a[i], item);
                }
                else
                {
                    dic[a[i]].Add(i + 1);
                }
            }

            for (int i = 0; i < Q; i++)
            {
                var q = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var qa = q[0]; var qb = q[1];
                if (dic.ContainsKey(qa))
                {
                    if (dic[qa].Count < qb) Console.WriteLine(-1);
                    else Console.WriteLine(dic[qa][qb - 1]);
                }
                else Console.WriteLine(-1);
            }
        }
    }
}
