using System;

namespace ABC075_C___Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var edges = new int[NM[1], 2];
            for (int i = 0; i < NM[1]; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                edges[i, 0] = ab[0];
                edges[i, 1] = ab[1];
            }

            var bridgeCount = 0;
            for (int removeEdge = 0; removeEdge < NM[1]; removeEdge++)
            {
                var union = new UnionFind(NM[0]);
                for (int edge = 0; edge < NM[1]; edge++)
                {
                    if (edge == removeEdge) continue;
                    union.unite(edges[edge, 0], edges[edge, 1]);
                }
                if (union.RootCount(1) != NM[0]) bridgeCount++;
            }
            Console.WriteLine(bridgeCount);
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
