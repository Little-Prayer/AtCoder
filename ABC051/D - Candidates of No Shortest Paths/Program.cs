using System;

namespace D___Candidates_of_No_Shortest_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var M = read[1];

            //2次元配列に辺と重さを記録
            var edges = new int[M,3];
            for(int i = 0 ; i < M ; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
                edges[i,0] = read[0];
                edges[i,1] = read[1];
                edges[i,2] = read[2];
            }

            //2次元配列に各頂点間の最短距離を記録
            var costs = new int[N+1,N+1];
            for(int i = 1 ; i < N+1 ; i++) for(int j = 1 ; j < N+1 ; j++) costs[i,j] = 1000000000;
            for(int i = 1 ; i < N+1 ; i++) costs[i,i] = 0;

            for(int i = 0 ; i < M ; i++)
            {
                costs[edges[i,0],edges[i,1]] = edges[i,2];
                costs[edges[i,1],edges[i,0]] = edges[i,2];
            }

            //Warshall-Floyd法で全ての頂点間の最短距離求める
            for(int via = 1 ; via < N+1 ; via++)
                for(int from = 1 ; from < N+1 ; from++)
                    for(int to = 1 ; to < N+1 ; to++) 
                        costs[from,to] = Math.Min(costs[from,to],costs[from,via]+costs[via,to]);

            //各辺の距離と両端の頂点間の最短距離を比較し、辺の距離のほうが長いものの数を出力
            var result = 0;
            for(int i = 0 ; i < M ; i++) if(costs[edges[i,0],edges[i,1]] != edges[i,2]) result++;

            Console.WriteLine(result);
            

        }
    }
}
