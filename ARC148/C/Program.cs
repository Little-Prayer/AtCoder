using System;
using System.Linq;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0]; var Q = NQ[1];
            var parent = new int[N + 1];
            var child = new int[N + 1];

            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < N - 1; j++)
            {
                parent[j + 2] = read[j];
                child[read[j]]++;
            }



            for (int i = 0; i < Q; i++)
            {
                var read2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var dic = new Dictionary<int, int>();
                foreach (int j in read2.Skip(1)) dic.Add(j, 0);

                var count = 0;
                foreach (int r in dic.Keys)
                {
                    count += child[r] + 1;
                    if (dic.ContainsKey(parent[r])) count -= 2;
                }
                Console.WriteLine(count);
            }
        }
    }
}
