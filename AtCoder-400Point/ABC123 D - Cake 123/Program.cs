using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC123_D___Cake_123
{
    class Program
    {
        static void Main(string[] args)
        {
            var XYZK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XYZK[0];
            var Y = XYZK[1];
            var Z = XYZK[2];
            var K = XYZK[3];

            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();

            var cakes = new PriorityQueue<Cake>(false);
            var isChecked = new bool[X, Y, Z];
            Func<int, int, int, Cake> makeCake = (a, b, c) =>
            {
                isChecked[a, b, c] = true;
                return new Cake(A[a] + B[b] + C[c], a, b, c);
            };
            cakes.Push(makeCake(0, 0, 0));


            for (int k = 0; k < K; k++)
            {
                var cur = cakes.Pop();
                Console.WriteLine(cur.Taste);
                if (cur.A != A.Length - 1 && !isChecked[cur.A + 1, cur.B, cur.C]) cakes.Push(makeCake(cur.A + 1, cur.B, cur.C));
                if (cur.B != B.Length - 1 && !isChecked[cur.A, cur.B + 1, cur.C]) cakes.Push(makeCake(cur.A, cur.B + 1, cur.C));
                if (cur.C != C.Length - 1 && !isChecked[cur.A, cur.B, cur.C + 1]) cakes.Push(makeCake(cur.A, cur.B, cur.C + 1));
            }
        }
    }
    struct Cake : IComparable<Cake>
    {
        public long Taste;
        public int A;
        public int B;
        public int C;
        public Cake(long taste, int a, int b, int c)
        {
            Taste = taste;
            A = a;
            B = b;
            C = c;
        }
        public int CompareTo(Cake other)
        {
            return this.Taste.CompareTo(other.Taste);
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
