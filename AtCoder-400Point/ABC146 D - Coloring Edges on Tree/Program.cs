using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146_D___Coloring_Edges_on_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var connections = new List<int>[N + 1];
            var edges = new List<int>[N + 1];
            var edgeColor = new int[N - 1];
            for (int i = 0; i < N + 1; i++)
            {
                connections[i] = new List<int>();
                edges[i] = new List<int>();
            }
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var a = ab[0]; var b = ab[1];
                connections[a].Add(b);
                connections[b].Add(a);
                edges[a].Add(i);
                edges[b].Add(i);
            }
            Console.WriteLine(edges.Select(n => n.Count).Max());

            var queue = new Queue<int>();
            queue.Enqueue(1);
            var parentColor = new int[N + 1];
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                var color = 1;
                for (int i = 0; i < connections[currentNode].Count; i++)
                {
                    var currentEdge = edges[currentNode][i];
                    if (edgeColor[currentEdge] != 0) continue;
                    if (color == parentColor[currentNode]) color++;
                    edgeColor[currentEdge] = color;
                    parentColor[connections[currentNode][i]] = color;
                    color++;
                    queue.Enqueue(connections[currentNode][i]);
                }
            }
            foreach (int i in edgeColor) Console.WriteLine(i);
        }
    }
}
