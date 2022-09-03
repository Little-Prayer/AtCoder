using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var listA = new List<long>();
            listA.Add(0);
            for (int i = 0; i < N; i++) listA.Add(A[i]);
            var link = new List<int>[N + 1];
            for (int i = 1; i <= N; i++) link[i] = new List<int>();
            var cost = new long[N + 1];
            for (int i = 0; i < M; i++)
            {
                var uv = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                link[uv[0]].Add(uv[1]);
                link[uv[1]].Add(uv[0]);
                cost[uv[0]] += listA[uv[1]];
                cost[uv[1]] += listA[uv[0]];
            }

            bool isCost(long K)
            {
                var pq = new PriorityQueue<node>(true);
                var isPicked = new bool[N + 1];
                for (int i = 1; i <= N; i++) pq.Push(new node(i, cost[i]));

                while (pq.Count() > 0)
                {
                    var current = pq.Pop();
                    if (isPicked[current.index]) continue;
                    if (current.cost < K) return false;
                    isPicked[current.index] = true;
                    var tempCost = new List<long>(cost);
                    foreach (int i in link[current.index])
                    {
                        tempCost[i] -= listA[current.index];
                        pq.Push(new node(i, tempCost[i]));
                    }
                }
                return true;
            }
            Console.WriteLine(lower_bound(1000000001, 0, isCost));
        }
        static long lower_bound(long ng, long ok, Func<long, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                long mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }

    class node : IComparable<node>
    {
        public int index;
        public long cost;

        public node(int i, long c)
        {
            this.index = i;
            this.cost = c;
        }
        public int CompareTo(node aite)
        {
            return this.cost.CompareTo(aite.cost);
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
