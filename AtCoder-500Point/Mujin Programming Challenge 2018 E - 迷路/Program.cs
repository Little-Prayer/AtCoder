using System;
using System.Collections.Generic;

namespace Mujin_Programming_Challenge_2018_E___迷路
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var height = NMK[0]; var width = NMK[1]; var K = NMK[2];
            var d = Console.ReadLine();
            var map = new long[height + 2, width + 2];
            for (int i = 0; i < width + 2; i++)
            {
                map[0, i] = -1;
                map[height + 1, i] = -1;
            }
            for (int i = 0; i < height + 2; i++)
            {
                map[i, 0] = -1;
                map[i, width + 1] = -1;
            }
            var SH = 0; var SW = 0; var GH = 0; var GW = 0;
            for (int i = 1; i < height + 1; i++)
            {
                var row = Console.ReadLine();
                for (int j = 1; j < width + 1; j++)
                {
                    if (row[j - 1] == '#')
                    {
                        map[i, j] = -1;
                    }
                    else
                    {
                        map[i, j] = long.MaxValue;
                        if (row[j - 1] == 'S')
                        {
                            SH = i; SW = j;
                        }
                        if (row[j - 1] == 'G')
                        {
                            GH = i; GW = j;
                        }
                    }
                }
            }
            map[SH, SW] = 0;

            var cost = new int[K, 4];
            var U = -1; var D = -1; var L = -1; var R = -1;
            for (int i = K - 1; i >= 0; i--)
            {
                if (d[i] == 'U') U = K + i;
                if (d[i] == 'D') D = K + i;
                if (d[i] == 'R') R = K + i;
                if (d[i] == 'L') L = K + i;
            }
            for (int i = K - 1; i >= 0; i--)
            {
                if (d[i] == 'U') U = i;
                if (d[i] == 'D') D = i;
                if (d[i] == 'R') R = i;
                if (d[i] == 'L') L = i;

                cost[i, 0] = U - i + 1;
                cost[i, 1] = R - i + 1;
                cost[i, 2] = D - i + 1;
                cost[i, 3] = L - i + 1;
            }

            var pq = new PriorityQueue<Edge>(true);
            if (map[SH - 1, SW] != -1 && cost[0, 0] != 0) pq.Push(new Edge(SH - 1, SW, cost[0, 0]));
            if (map[SH, SW + 1] != -1 && cost[0, 1] != 0) pq.Push(new Edge(SH, SW + 1, cost[0, 1]));
            if (map[SH + 1, SW] != -1 && cost[0, 2] != 0) pq.Push(new Edge(SH + 1, SW, cost[0, 2]));
            if (map[SH, SW - 1] != -1 && cost[0, 3] != 0) pq.Push(new Edge(SH, SW - 1, cost[0, 3]));
            while (pq.Count() > 0)
            {
                var cur = pq.Pop();
                var cos = cur.Cost;
                var NH = cur.ToH;
                var NW = cur.ToW;
                if (cos < map[NH, NW])
                {
                    map[NH, NW] = cos;
                    if (map[NH - 1, NW] != -1 && cost[0, 0] != 0) pq.Push(new Edge(NH - 1, NW, cos + cost[cos % K, 0]));
                    if (map[NH, NW + 1] != -1 && cost[0, 1] != 0) pq.Push(new Edge(NH, NW + 1, cos + cost[cos % K, 1]));
                    if (map[NH + 1, NW] != -1 && cost[0, 2] != 0) pq.Push(new Edge(NH + 1, NW, cos + cost[cos % K, 2]));
                    if (map[NH, NW - 1] != -1 && cost[0, 3] != 0) pq.Push(new Edge(NH, NW - 1, cos + cost[cos % K, 3]));
                }
            }

            Console.WriteLine(map[GH, GW] == long.MaxValue ? -1 : map[GH, GW]);
        }
    }
    struct Edge : IComparable<Edge>
    {
        public int ToH;
        public int ToW;
        public long Cost;
        public Edge(int th, int tw, long cos)
        {
            ToH = th;
            ToW = tw;
            Cost = cos;
        }
        public int CompareTo(Edge other)
        {
            return Cost.CompareTo(other.Cost);
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
