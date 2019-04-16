using System;

namespace D___Decayed_Bridges
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp1 = Console.ReadLine().Split(' ');
            int N = int.Parse(temp1[0]);
            int M = int.Parse(temp1[1]);

            var decayed = new int[M,2];
            for(int i=0;i<M;i++)
            {
                var temp2 = Console.ReadLine().Split(' ');
                decayed[i,0] = int.Parse(temp2[0]);
                decayed[i,1] = int.Parse(temp2[1]);
            }

            var inconvenience = new long[M];
            inconvenience[M-1] = N*(N-1)/2;

            var islandGroup = new UnionFind(N);

            for(int i = M-2;i>=0;i--)
            {
                int X = decayed[i,0];
                int Y = decayed[i,1];

                if(islandGroup.sameRoot(X,Y))
                {
                    inconvenience[i] = inconvenience[i+1];
                }else{
                    inconvenience[i] = inconvenience[i+1] - (islandGroup.rootCount[X]*islandGroup.rootCount[Y]);
                    islandGroup.unite(X,Y);
                }
            }

            foreach(long i in inconvenience)
            {
                Console.WriteLine(i);
            }
        }
    }
    
    public class UnionFind
    {
        private int[] parents;
        // 同じ根に属する枝の数を格納する
        public int[] rootCount{get;}
        
        public UnionFind(int count)
        {
            parents = new int[count+1];
            rootCount = new int[count+1];
            for(int i = 0 ;i<=count;i++)
            {
                parents[i] = i;
                rootCount[i] = 1;
            }
        }

        private int root(int N)
        {
            if(parents[N] == N) return N;
            return parents[N] = root(parents[N]);
        }

        //木を併合する際に、枝の数も合算する
        public void unite(int X,int Y)
        {
            int rootX = root(X);
            int rootY = root(Y);
            if(rootX==rootY) return;
            rootCount[rootX] += rootCount[rootY];
            parents[rootY] = rootX;
        }

        public bool sameRoot(int X,int Y)
        {
            return root(X)==root(Y);
        }

    }
}
