using System;
using System.Collections.Generic;
using System.Linq;

namespace _021___Come_Back_in_One_Piece_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var map = new List<int>[N + 1];
            var reverse = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                map[i] = new List<int>();
                reverse[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                map[ab[0]].Add(ab[1]);
                reverse[ab[1]].Add(ab[0]);
            }

            var seen = new bool[N + 1];
            var rabel = new int[N + 1];
            var rabeling = 0;

            int start = 1;
            while (start > 0)
            {
                dfs(start);
                start = 0;
                for (int i = 1; i < N + 1; i++)
                {
                    if (!seen[i])
                    {
                        start = i;
                        break;
                    }
                }
            }

            void dfs(int current)
            {
                if (seen[current]) return;
                seen[current] = true;
                foreach (int next in map[current]) dfs(next);
                rabel[current] = rabeling;
                rabeling++;
            }
            var pq = new PriorityQueue<node>(false);
            for (int i = 1; i < N + 1; i++) pq.Push(new node(i, rabel[i]));
            var seenReverse = new bool[N + 1];

            long result = 0;
            long subtotal = 0;
            while (pq.Count() > 0)
            {
                var current = pq.Pop();
                if (seenReverse[current.number]) continue;
                subtotal = 0;
                dfsReverse(current.number);
                result += subtotal * (subtotal - 1) / 2;
            }
            Console.WriteLine(result);
            void dfsReverse(int current)
            {
                if (seenReverse[current]) return;
                seenReverse[current] = true;
                foreach (int next in reverse[current]) dfsReverse(next);
                subtotal++;
            }

        }
    }
    class node : IComparable<node>
    {
        public int number { get; }
        public int rabel { get; }

        public node(int num, int rab)
        {
            number = num;
            rabel = rab;
        }

        public int CompareTo(node other)
        {
            return this.rabel.CompareTo(other.rabel);
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
