using System;
using System.Linq;
using System.Collections.Generic;

namespace CF2017_qual_B_C___3_Steps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var nodes = new Node[N + 1];
            for (int i = 0; i < N + 1; i++) nodes[i] = new Node();
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                nodes[ab[0]].connection.Add(ab[1]);
                nodes[ab[1]].connection.Add(ab[0]);
            }

            var queue = new Queue<Node>();
            queue.Enqueue(nodes[1]);
            var isSearch = new bool[N + 1];
            isSearch[1] = true;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (int n in current.connection)
                {
                    if (isSearch[n])
                    {
                        if (current.isBlack == nodes[n].isBlack) return (long)N * (long)(N - 1) / 2 - M;
                    }
                    else
                    {
                        isSearch[n] = true;
                        nodes[n].isBlack = !current.isBlack;
                        queue.Enqueue(nodes[n]);
                    }
                }
            }
            var black = nodes.Count(n => n.isBlack);
            return (long)black * (long)(N - black) - M;
        }

        class Node
        {
            public List<int> connection;
            public bool isBlack;
            public Node()
            {
                connection = new List<int>();
            }
        }
    }
}
