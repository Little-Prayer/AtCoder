using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
            bool solver()
            {
                var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var map = new List<int>[NM[0] + 1];
                for (int i = 0; i < NM[0] + 1; i++) map[i] = new List<int>();
                var uf = new UnionFind(NM[0]);

                for (int i = 0; i < NM[1]; i++)
                {
                    var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    if (uf.sameRoot(ab[0], ab[1])) return false;
                    map[ab[0]].Add(ab[1]);
                    map[ab[1]].Add(ab[0]);
                    uf.unite(ab[0], ab[1]);
                    if (map[ab[0]].Count > 2 || map[ab[1]].Count > 2) return false;
                }
                return true;

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

}
