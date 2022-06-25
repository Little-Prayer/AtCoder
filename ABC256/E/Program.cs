using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var total = new long[N + 1];
            for (int i = 0; i < N; i++)
            {
                total[X[i]] += C[i];
            }
            var pq = new PriorityQueue<hito>(true);
            for (int i = 1; i < N + 1; i++) pq.Push(new hito(i, total[i]));
            long result = 0;
            var isCandy = new bool[N + 1];
            while (pq.Count() > 0)
            {
                var current = pq.Pop();
                if (isCandy[current.index]) continue;
                result += current.count;
                total[X[current.index - 1]] -= C[current.index - 1];
                pq.Push(new hito(X[current.index - 1], total[X[current.index - 1]]));
                isCandy[current.index] = true;
            }
            Console.WriteLine(result);
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
        class hito : IComparable<hito>
        {
            public int index { get; set; }
            public long count { get; set; }
            public int CompareTo(hito aite)
            {
                return this.count.CompareTo(aite.count);
            }
            public hito(int i, long c)
            {
                this.index = i;
                this.count = c;
            }
        }
    }
}
