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

            var dic = new Dictionary<long, Dictionary<long, long>>();
            for (int i = 0; i < Q; i++)
            {
                var TAB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                var T = TAB[0]; var A = TAB[1]; var B = TAB[2];
                if (T == 1)
                {
                    if (!dic.ContainsKey(A))
                    {
                        dic.Add(A, new Dictionary<long, long>());
                    }
                    if (!dic[A].ContainsKey(B))
                    {
                        dic[A].Add(B, 0);
                    }
                }
                if (T == 2)
                {
                    if (dic.ContainsKey(A))
                    {
                        if (dic[A].ContainsKey(B))
                        {
                            dic[A].Remove(B);
                        }
                    }
                }
                if (T == 3)
                {

                    if (dic.ContainsKey(A) && dic.ContainsKey(B))
                    {
                        Console.WriteLine(dic[A].ContainsKey(B) && dic[B].ContainsKey(A) ? "Yes" : "No");
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
            }
        }
    }
}
