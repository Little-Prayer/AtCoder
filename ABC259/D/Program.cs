using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var st = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            (long x, long y) s = (st[0], st[1]); (long x, long y) t = (st[2], st[3]);
            var rings = new (long x, long y, long r)[N];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                rings[i] = (read[0], read[1], read[2]);
            }

            var uf = new UnionFind(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    var distance = (rings[i].x - rings[j].x) * (rings[i].x - rings[j].x) + (rings[i].y - rings[j].y) * (rings[i].y - rings[j].y);
                    if (distance <= (rings[i].r + rings[j].r) * (rings[i].r + rings[j].r) && distance >= (rings[i].r - rings[j].r) * (rings[i].r - rings[j].r))
                        uf.unite(i, j);
                }
            }
            var sring = -1;
            var tring = -1;
            for (int i = 0; i < N; i++)
            {
                if (Math.Sqrt((rings[i].x - s.x) * (rings[i].x - s.x) + (rings[i].y - s.y) * (rings[i].y - s.y)) == rings[i].r) sring = i;
                if (Math.Sqrt((rings[i].x - t.x) * (rings[i].x - t.x) + (rings[i].y - t.y) * (rings[i].y - t.y)) == rings[i].r) tring = i;
            }
            Console.WriteLine(uf.sameRoot(sring, tring) ? "Yes" : "No");
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
