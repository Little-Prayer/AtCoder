using System;
using System.Collections.Generic;

namespace ARC065_D___連結
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NKL[0]; var K = NKL[1]; var L = NKL[2];

            var connectingRoad = new UnionFind(N);
            for (int i = 0; i < K; i++)
            {
                var pq = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connectingRoad.unite(pq[0], pq[1]);
            }

            var connectingTrain = new UnionFind(N);
            for (int i = 0; i < L; i++)
            {
                var rs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connectingTrain.unite(rs[0], rs[1]);
            }

            var sameRootCount = new Dictionary<long, int>();
            for (int i = 1; i < N + 1; i++)
            {
                long root = (long)connectingRoad.root(i) + (long)connectingTrain.root(i) * 1000000;
                if (sameRootCount.ContainsKey(root)) sameRootCount[root]++;
                else sameRootCount.Add(root, 1);
            }

            var result = new int[N];
            for (int i = 0; i < N; i++) result[i] = sameRootCount[(long)connectingRoad.root(i + 1) + (long)connectingTrain.root(i + 1) * 1000000];

            Console.WriteLine(String.Join(" ", result));
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

        public int root(int N)
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
