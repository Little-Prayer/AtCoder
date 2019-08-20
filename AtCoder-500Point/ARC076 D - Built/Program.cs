using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC076_D___Built
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var points = new Point[N];
            for (int i = 0; i < N; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                points[i] = new Point(i + 1, xy[0], xy[1]);
            }

            var edges = new PriorityQueue<Edge>(true);
            points = points.OrderBy(p => p.x).ToArray();
            for (int i = 0; i + 1 < N; i++) edges.Push(new Edge(points[i], points[i + 1], Math.Abs(points[i].x - points[i + 1].x)));
            points = points.OrderBy(p => p.y).ToArray();
            for (int i = 0; i + 1 < N; i++) edges.Push(new Edge(points[i], points[i + 1], Math.Abs(points[i].y - points[i + 1].y)));

            var union = new UnionFind(N);
            long result = 0;
            while (edges.Count() != 0)
            {
                var currentEdge = edges.Pop();
                if (!union.sameRoot(currentEdge.from.number, currentEdge.to.number))
                {
                    union.unite(currentEdge.from.number, currentEdge.to.number);
                    result += currentEdge.cost;
                }
            }
            Console.WriteLine(result);
        }
    }
    struct Point
    {
        public int number;
        public int x;
        public int y;

        public Point(int _number, int _x, int _y)
        {
            number = _number;
            x = _x;
            y = _y;
        }
    }
    struct Edge : IComparable<Edge>
    {
        public Point from;
        public Point to;
        public int cost;
        public Edge(Point _from, Point _to, int _cost)
        {
            from = _from;
            to = _to;
            cost = _cost;
        }
        public int CompareTo(Edge otherEdge)
        {
            return cost.CompareTo(otherEdge.cost);
        }
    }

    public class UnionFind
    {
        private int[] parents;
        // 同じ根に属する枝の数を格納する
        private int[] rootCount;

        public int RootCount(int branch)
        {
            return rootCount[root(branch)];
        }

        public UnionFind(int count)
        {
            parents = new int[count + 1];
            rootCount = new int[count + 1];
            for (int i = 0; i < count + 1; i++)
            {
                parents[i] = i;
                rootCount[i] = 1;
            }
        }

        private int root(int N)
        {
            if (parents[N] == N) return N;
            return parents[N] = root(parents[N]);
        }

        //木を併合する際に、枝の数も合算する
        public void unite(int X, int Y)
        {
            int rootX = root(X);
            int rootY = root(Y);
            if (rootX == rootY) return;
            rootCount[rootX] += rootCount[rootY];
            parents[rootY] = rootX;
        }

        public bool sameRoot(int X, int Y)
        {
            return root(X) == root(Y);
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
