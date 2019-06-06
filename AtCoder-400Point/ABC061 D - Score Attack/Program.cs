using System;

namespace ABC061_D___Score_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var M = read[1];
            var edges = new Edge[M];

            for(i = 0 ; i < M ; i++)
            {
                var read2 = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                edges[i] = new Edge(read2[0],read2[1],-read2[2]);
            }

            var distance = new long[N+1];
            distance[1] = 0;
            for(i = 2 ; i < N ; i++) distance[i] = long.MaxValue;

            var update = new bool[N+1];

            
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
