using System;
using System.Collections.Generic;
using System.Linq;

namespace _039___Tree_Distance_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var tree = new node[N + 1];
            for (int i = 0; i <= N; i++) tree[i] = new node();
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                tree[ab[0]].connections.Add(ab[1]);
                tree[ab[1]].connections.Add(ab[0]);
            }

            long countChildren(int parent, int current)
            {
                tree[current].parent = parent;
                var children = tree[current].connections.Where(x => x != parent);
                if (children.Count() == 0) tree[current].descendant = 1;
                else tree[current].descendant = children.Sum(x => countChildren(current, x)) + 1;

                return tree[current].descendant;
            }
            countChildren(0, 1);

            Console.WriteLine(tree.Sum(t => t.descendant * (N - t.descendant)));
        }
    }

    class node
    {
        public int parent;
        public List<int> connections;

        public long descendant;
        public node() { connections = new List<int>(); }

    }
}
