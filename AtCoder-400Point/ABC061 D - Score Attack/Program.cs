using System;

namespace ABC061_D___Score_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = read[0];
            var M = read[1];
            var edges = new Edge[M];

            for(int i = 0 ; i < M ; i++)
            {
                var read2 = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                edges[i] = new Edge(read2[0],read2[1],-read2[2]);
            }

            var distance = new long[N+1];
            distance[1] = 0;
            for(int i = 2 ; i < N+1 ; i++) distance[i] = long.MaxValue;

            var update = new bool[N+1];
            bool isInfinite = false;
            
            for(int i = 0 ; i < N ; i++)
            {
                for(int j = 0 ; j < N+1 ; j++) update[j] = false;
                for(int k = 0 ; k < M ; k++)
                {
                    if(distance[edges[k].from] == long.MaxValue) continue;
                    if(distance[edges[k].to] > distance[edges[k].from] + edges[k].cost)
                    {
                        distance[edges[k].to] = distance[edges[k].from] + edges[k].cost;
                        update[edges[k].to] = true;
                        update[edges[k].from] = true;
                        if(i == N-1)
                        {
                            if(update[N]==true) isInfinite = true;
                        }
                    }
                }
            }
            if(isInfinite == true)
            {
                Console.WriteLine("inf");
            }else
            {
                Console.WriteLine(-distance[N]);
            }
        }
        struct Edge
        {
            public long from{get;set;}
            public long to{get;set;}
            public long cost{get;set;}
            public Edge(long _from,long _to,long _cost)
            {
                this.from = _from;
                this.to = _to;
                this.cost = _cost;
            }
        }
    }
}
