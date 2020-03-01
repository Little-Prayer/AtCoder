using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            var friendship = new UnionFind(N);
            var friend = new int[N + 1];
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                friendship.unite(read[0], read[1]);
                friend[read[0]]++;
                friend[read[1]]++;
            }
            var suggestions = new int[N];
            for (int i = 0; i < N; i++) suggestions[i] = friendship.RootCount(i + 1) - friend[i + 1] - 1;
            for (int i = 0; i < K; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (friendship.sameRoot(read[0], read[1]))
                {
                    suggestions[read[0] - 1]--;
                    suggestions[read[1] - 1]--;
                }
            }
            Console.WriteLine(string.Join(" ", suggestions));
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
