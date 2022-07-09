using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var dic = new Dictionary<long, (long num, int index)>();
            for (int i = 0; i < N; i++)
            {
                var M = int.Parse(Console.ReadLine());
                for (int j = 0; j < M; j++)
                {
                    var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                    if (dic.ContainsKey(read[0]))
                    {
                        if (read[1] > dic[read[0]].num) dic[read[0]] = (read[1], i);
                    }
                    else
                    {
                        dic.Add(read[0], (read[1], i));
                    }
                }
            }

            var set = new HashSet<int>();
            foreach (var item in dic)
            {
                set.Add(item.Value.index);
            }
            Console.WriteLine(set.Count + (N == 1 ? 0 : 1));
        }
    }
}
