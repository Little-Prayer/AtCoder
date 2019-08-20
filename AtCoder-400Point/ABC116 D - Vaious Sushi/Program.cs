using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC116_D_Vaious_Sushi
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];
            var netaTops = new long[N + 1];
            var remainingSushi = new PriorityQueue<long>(false);
            for (int i = 0; i < N; i++)
            {
                var td = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                if (td[1] > netaTops[td[0]])
                {
                    if (netaTops[td[0]] != 0) remainingSushi.Push(netaTops[td[0]]);
                    netaTops[td[0]] = td[1];
                }
                else
                {
                    remainingSushi.Push(td[1]);
                }
            }
            netaTops = netaTops.Where(n => n != 0).OrderByDescending(n => n).ToArray();
            var netaVariation = Math.Min(K, netaTops.Length);
            var maxPoints = new long[netaVariation + 1];
            var pickingSushi = new PriorityQueue<long>(true);
            for (int i = 0; i < netaVariation; i++)
            {
                if (i < K)
                {
                    maxPoints[netaVariation] += netaTops[i];
                    pickingSushi.Push(netaTops[i]);
                }
                else
                {
                    remainingSushi.Push(netaTops[i]);
                }
            }
            for (int i = 0; i < K - netaVariation; i++)
            {
                maxPoints[netaVariation] += remainingSushi.Top();
                pickingSushi.Push(remainingSushi.Pop());
            }
            for (int i = netaVariation - 1; i > 0; i--)
            {
                if (remainingSushi.Count() != 0 && remainingSushi.Top() > pickingSushi.Top())
                {
                    maxPoints[i] = maxPoints[i + 1] - pickingSushi.Pop() + remainingSushi.Top();
                    pickingSushi.Push(remainingSushi.Pop());
                }
                else
                {
                    maxPoints[i] = maxPoints[i + 1];
                }
            }
            long maxPoint = 0;
            for (long i = 1; i <= Math.Min(K, netaVariation); i++) maxPoint = Math.Max(maxPoint, maxPoints[i] + i * i);
            Console.WriteLine(maxPoint);
        }
    }
    class PriorityQueue<T> where T : IComparable
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
