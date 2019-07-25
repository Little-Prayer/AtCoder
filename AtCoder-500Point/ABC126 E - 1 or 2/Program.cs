using System;

namespace ABC126_E___1_or_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var union = new UnionFind(NM[0]);
            for (int i = 0; i < NM[1]; i++)
            {
                var xyz = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                union.unite(xyz[0], xyz[1]);
            }
            Console.WriteLine(union.UnionCount);
        }
    }
    public class UnionFind
    {
        private int[] parents;
        // 同じ根に属する枝の数を格納する
        private int[] rootCount;
        public int UnionCount;

        public int RootCount(int branch)
        {
            return rootCount[root(branch)];
        }

        public UnionFind(int count)
        {
            parents = new int[count + 1];
            rootCount = new int[count + 1];
            UnionCount = count;
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
            UnionCount -= 1;
        }

        public bool sameRoot(int X, int Y)
        {
            return root(X) == root(Y);
        }

    }
}
