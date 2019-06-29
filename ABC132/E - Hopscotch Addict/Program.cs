using System;
using System.Collections.Generic;

namespace E___Hopscotch_Addict
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var nodes = new Node[NM[0] + 1];
            for (int i = 0; i < NM[0] + 1; i++) nodes[i] = new Node();
            for (int i = 0; i < NM[1]; i++)
            {
                var edge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                nodes[edge[0]].connection.Add(edge[1]);
            }

            nodes[1].isReach = true;
            var search = new Queue<int>();
            var subSearch = new Queue<int>();
            search.Enqueue(nodes[1]);
            while (search.Count != 0)
            {
                var currentNode = search.Dequeue();
                foreach (int i in nodes[currentNode].connection) subSearch.Enqueue(i);
                for (int i = 0; i < 3; i++)
                {

                }
            }
        }
    }
    class Node
    {
        public List<int> connection;
        public bool isReach;
        public Node()
        {
            connection = new List<int>();
            isReach = false;
        }
    }
}
