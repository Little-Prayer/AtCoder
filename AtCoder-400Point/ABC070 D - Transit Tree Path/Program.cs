using System;
using System.Collections.Generic;

namespace ABC070_D___Transit_Tree_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var nodes = new Node[N + 1];
            for (int i = 1; i < N + 1; i++) nodes[i] = new Node();
            for (int i = 0; i < N - 1; i++)
            {
                var readEdge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                nodes[readEdge[0]].connection.Add(readEdge[1]);
                nodes[readEdge[0]].distance.Add(readEdge[2]);
                nodes[readEdge[1]].connection.Add(readEdge[0]);
                nodes[readEdge[1]].distance.Add(readEdge[2]);
            }

            var QK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            nodes[QK[1]].fromK = 0;
            var checkNodes = new Queue<Node>();
            checkNodes.Enqueue(nodes[QK[1]]);

            while (checkNodes.Count != 0)
            {
                var currentNode = checkNodes.Dequeue();
                for (int i = 0; i < currentNode.connection.Count; i++)
                {
                    var nextNode = nodes[currentNode.connection[i]];
                    if (nextNode.fromK != -1) continue;
                    checkNodes.Enqueue(nextNode);
                    nextNode.fromK = currentNode.fromK + currentNode.distance[i];
                }
            }

            for (int i = 0; i < QK[0]; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(nodes[xy[0]].fromK + nodes[xy[1]].fromK);
            }
        }
    }

    class Node
    {
        public List<int> connection;
        public List<long> distance;
        public long fromK;
        public Node()
        {
            connection = new List<int>();
            distance = new List<long>();
            fromK = -1;
        }
    }
}
