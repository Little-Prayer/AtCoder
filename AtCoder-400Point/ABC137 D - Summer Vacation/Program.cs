using System;
using System.Collections.Generic;

namespace ABC137_D___Summer_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];

            var jobs = new List<int>[M + 1];
            for (int i = 0; i < M + 1; i++) jobs[i] = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (ab[0] <= M) jobs[ab[0]].Add(ab[1]);
            }

            var acceptablleJobs = new PriorityQueue<int>(false);
            long rewardSum = 0;
            for (int day = 1; day <= M; day++)
            {
                foreach (int r in jobs[day]) acceptablleJobs.Push(r);
                if (acceptablleJobs.Count() > 0) rewardSum += acceptablleJobs.Pop();
            }

            Console.WriteLine(rewardSum);
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
