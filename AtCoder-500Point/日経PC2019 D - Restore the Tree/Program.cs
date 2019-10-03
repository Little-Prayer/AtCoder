using System;
using System.Collections.Generic;
using System.Linq;

namespace 日経PC2019_D___Restore_the_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var to = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) to[i] = new List<int>();
            var indegree = new int[N + 1];
            indegree[0] = -1;
            for (int i = 0; i < N + M - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                to[ab[0]].Add(ab[1]);
                indegree[ab[1]]++;
            }

            var queue = new Queue<int>();
            int root = 1;
            for (; root < N + 1; root++) if (indegree[root] == 0) break;
            var parents = new int[N + 1];
            parents[root] = 0;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();
                foreach (int e in to[parent])
                {
                    indegree[e]--;
                    if (indegree[e] == 0)
                    {
                        parents[e] = parent;
                        queue.Enqueue(e);
                    }
                }
            }

            for (int i = 1; i < N + 1; i++) Console.WriteLine(parents[i]);
        }
    }
}
