using System;
using System.Linq;

namespace _012___Red_Painting_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var isRed = Enumerable.Repeat<bool>(false, H * W + 1).ToArray();
            var union = new UnionFind(H * W);
            var Q = int.Parse(Console.ReadLine());

            for (int i = 0; i < Q; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                if (read[0] == 1)
                {
                    var r = read[1]; var c = read[2];
                    var point = (r - 1) * W + c;
                    isRed[point] = true;
                    if (r > 1 && isRed[(r - 2) * W + c]) union.unite(point, (r - 2) * W + c);
                    if (r < H && isRed[r * W + c]) union.unite(point, r * W + c);
                    if (c > 1 && isRed[(r - 1) * W + c - 1]) union.unite(point, (r - 1) * W + c - 1);
                    if (c < W && isRed[(r - 1) * W + c + 1]) union.unite(point, (r - 1) * W + c + 1);
                }
                else
                {
                    var ra = read[1]; var ca = read[2]; var rb = read[3]; var cb = read[4];
                    var pointA = (ra - 1) * W + ca; var pointB = (rb - 1) * W + cb;
                    Console.WriteLine(isRed[pointA] && isRed[pointB] && union.sameRoot(pointA, pointB) ? "Yes" : "No");
                }
            }
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
