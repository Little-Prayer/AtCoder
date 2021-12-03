using System;
using System.Collections.Generic;

namespace _013___Passing_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var map = new List<Edge>[NM[0] + 1];
            for (int i = 0; i < map.Length; i++) map[i] = new List<Edge>();

            for (int i = 0; i < NM[1]; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                map[read[0]].Add(new Edge(read[1], read[2]));
                map[read[1]].Add(new Edge(read[0], read[2]));
            }

            var costFromStart = dijkstra(1, map);
            var costFromEnd = dijkstra(NM[0], map);

            for (int i = 1; i <= NM[0]; i++) Console.WriteLine(costFromStart[i] + costFromEnd[i]);
        }

        static long[] dijkstra(int start, List<Edge>[] map)
        {
            var costs = new long[map.Length];
            for (int i = 0; i < costs.Length; i++) costs[i] = i == start ? 0 : long.MaxValue;

            var pq = new PriorityQueue<Vertex>(true);
            foreach (Edge e in map[start]) pq.Push(new Vertex(e.to, e.cost));

            while (pq.Count() > 0)
            {
                var current = pq.Pop();
                if (costs[current.to] > current.cost) costs[current.to] = current.cost;
                else continue;

                foreach (Edge e in map[current.to]) pq.Push(new Vertex(e.to, current.cost + e.cost));
            }

            return costs;
        }
    }
    struct Edge
    {
        public int to { get; }
        public int cost { get; }
        public Edge(int _to, int _cost)
        {
            to = _to;
            cost = _cost;
        }
    }

    struct Vertex : IComparable<Vertex>
    {
        public int to { get; }
        public int cost { get; }

        public Vertex(int _to, int _cost)
        {
            to = _to;
            cost = _cost;
        }
        public int CompareTo(Vertex other)
        {
            return this.cost.CompareTo(other.cost);
        }
    }
    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> nodes;
        private Boolean isAsc;

        public PriorityQueue(Boolean _isAsc)
        {
            this.nodes = new List<T>();
            this.isAsc = _isAsc;
        }

        public int Count()
        {
            return this.nodes.Count;
        }
        public T Pop()
        {
            T returnNode = this.nodes[0];
            this.nodes[0] = this.nodes[nodes.Count - 1];
            this.nodes.RemoveAt(nodes.Count - 1);
            int root = 0;
            while (root * 2 + 1 < this.nodes.Count)
            {
                int child = root * 2 + 1;
                if (child + 1 < this.nodes.Count && compare(this.nodes[child + 1], this.nodes[child]) > 0) child += 1;
                if (compare(this.nodes[child], this.nodes[root]) > 0)
                {
                    swap(child, root);
                    root = child;
                }
                else
                {
                    break;
                }
            }
            return returnNode;
        }
        public T Top()
        {
            return this.nodes[0];
        }
        public void Push(T t)
        {
            this.nodes.Add(t);
            var addPosition = nodes.Count - 1;
            while (addPosition > 0)
            {
                var parent = (int)(addPosition - 1) / 2;
                if (compare(nodes[addPosition], nodes[parent]) > 0)
                {
                    swap(addPosition, parent);
                    addPosition = parent;
                }
                else
                {
                    break;
                }
            }
        }
        private int compare(T x, T y)
        {
            return this.isAsc ? y.CompareTo(x) : x.CompareTo(y);
        }
        private void swap(int x, int y)
        {
            T temp = nodes[x];
            nodes[x] = nodes[y];
            nodes[y] = temp;
        }
    }
}
