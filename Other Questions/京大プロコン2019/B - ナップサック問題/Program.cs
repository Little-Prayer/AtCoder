using System;
using System.Collections.Generic;
using System.Linq;

namespace B___ナップサック問題
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMW[0]; var M = NMW[1]; var W = NMW[2];
            var values = new int[N + 1];
            var weights = new int[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                var wv = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                weights[i] = wv[0];
                values[i] = wv[1];
            }

            var union = new UnionFind(N, weights, values);
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (!union.sameRoot(ab[0], ab[1])) union.unite(ab[0], ab[1]);
            }
            union.compression();

            var groupWeights = new List<int>();
            var groupValues = new List<int>();
            foreach (int root in union.parents.Distinct())
            {
                groupWeights.Add(union.weightSum[root]);
                groupValues.Add(union.valueSum[root]);
            }

            var setCount = groupWeights.Count - 1;
            var DP = new long[setCount + 1, W + 1];
            for (int s = 1; s < setCount + 1; s++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (w >= groupWeights[s])
                        DP[s, w] = Math.Max(DP[s - 1, w], DP[s - 1, w - groupWeights[s]] + groupValues[s]);
                    else
                        DP[s, w] = DP[s - 1, w];
                }
            }
            Console.WriteLine(DP[setCount, W].ToString());
        }
    }
    public class UnionFind
    {
        public int[] parents;
        public int[] weightSum;
        public int[] valueSum;


        public UnionFind(int count, int[] weights, int[] values)
        {
            parents = new int[count + 1];
            weightSum = new int[count + 1];
            valueSum = new int[count + 1];
            for (int i = 0; i < count + 1; i++)
            {
                parents[i] = i;
                weightSum[i] = weights[i];
                valueSum[i] = values[i];
            }
        }

        public void compression()
        {
            for (int i = 1; i < parents.Length; i++)
            {
                root(i);
            }
        }

        private int root(int N)
        {
            if (parents[N] == N) return N;
            return parents[N] = root(parents[N]);
        }

        public void unite(int X, int Y)
        {
            int rootX = root(X);
            int rootY = root(Y);
            if (rootX == rootY) return;
            weightSum[rootX] += weightSum[rootY];
            valueSum[rootX] += valueSum[rootY];
            parents[rootY] = rootX;
        }

        public bool sameRoot(int X, int Y)
        {
            return root(X) == root(Y);
        }
    }
}
