using System;

namespace _012___Red_Painting_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

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
}
