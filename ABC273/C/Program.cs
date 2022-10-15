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

            var dic = new Dictionary<int, int>();
            foreach (int alpha in A)
                if (!dic.ContainsKey(alpha)) dic.Add(alpha, 0);
            var orderedDic = dic.Keys.OrderByDescending(n => n).ToArray();
            for (int i = 0; i < orderedDic.Length; i++) dic[orderedDic[i]] = i;

            var K = new int[N];
            foreach (int alpha in A) K[dic[alpha]]++;
            for (int i = 0; i < N; i++) Console.WriteLine(K[i]);
        }
    }
}
