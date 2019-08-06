using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC074_D___3N_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var front = new PriorityQueue<long>(true);
            for (int i = 0; i < N; i++) front.Push(Ai[i]);


            var center = new long[N];
            Array.Copy(Ai, N, center, 0, N);

            var back = new PriorityQueue<long>(false);
            for (int i = 0; i < N; i++) back.Push(Ai[i + 2 * N]);

            var sumFront = new long[N + 1];
            sumFront[0] = Ai.Take(N).Sum();
            for (int i = 1; i < N + 1; i++)
            {
                front.Push(center[i - 1]);
                sumFront[i] = sumFront[i - 1] - front.Pop() + center[i - 1];
            }

            var sumBack = new long[N + 1];
            sumBack[N] = Ai.Skip(2 * N).Sum();
            for (int i = N - 1; i >= 0; i--)
            {
                back.Push(center[i]);
                sumBack[i] = sumBack[i + 1] - back.Pop() + center[i];
            }

            var score = new long[N + 1];
            for (int i = 0; i < N + 1; i++) score[i] = sumFront[i] - sumBack[i];

            Console.WriteLine(score.Max());
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
