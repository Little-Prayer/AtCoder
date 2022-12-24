using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var connection = new List<int>[N + 1];
            for (int i = 0; i <= N; i++) connection[i] = new List<int>();

            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[read[0]].Add(read[1]);
                connection[read[1]].Add(read[0]);
            }

            var color = new int[N + 1];
            color[0] = int.MinValue;
            var uf = new UnionFind(N);

            while (color.Where(i => i == 0).Count() > 0)
            {
                var queue = new Queue<int>();
                int encolored;
                for (encolored = 1; encolored <= N; encolored++)
                {
                    if (color[encolored] == 0) break;
                }
                queue.Enqueue(encolored);
                color[encolored] = 1;
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    foreach (int node in connection[current])
                    {
                        uf.unite(current, node);
                        if (color[node] == 0)
                        {
                            color[node] = -1 * color[current];
                            queue.Enqueue(node);
                        }
                        else if (color[node] == color[current])
                        {
                            return 0;
                        }
                    }
                }

            }

            var dic = new Dictionary<string, long>();
            for (int i = 1; i <= N; i++)
            {
                var current = uf.root(i).ToString("00000000") + (color[i] + 2).ToString();
                if (dic.ContainsKey(current))
                {
                    dic[current]++;
                }
                else
                {
                    dic.Add(current, 1);
                }
            }

            long result = 0;
            for (int i = 1; i <= N; i++)
            {
                result += N - dic[uf.root(i).ToString("00000000") + (color[i] + 2).ToString()] - connection[i].Count();
            }
            return result / 2;
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
