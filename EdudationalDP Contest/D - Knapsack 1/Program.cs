using System;
using System.Linq;

namespace D___Knapsack_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var N = read[0];
            var W = read[1];

            var items = new int[N+1,2];
            for(int i = 1 ; i < N+1 ; i++)
            {
                read = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                items[i,0] = read[0];
                items[i,1] = read[1];
            }

            var DP = new long[N+1,W+1];
            for(int item = 1 ; item < N+1 ; item++)
            {
                for(int weight = 1 ; weight < W+1 ; weight++)
                {
                    if(weight >= items[item,0])
                    {
                        DP[item,weight] = Math.Max(DP[item-1,weight],DP[item-1,weight-items[item,0]] + items[item,1]);
                    }else{
                        DP[item,weight] = DP[item-1,weight];
                    }
                }
            }

            Console.WriteLine(DP[N,W]);
        }
    }
}
