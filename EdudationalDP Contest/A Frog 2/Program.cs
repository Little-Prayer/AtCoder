using System;
using System.Linq;

namespace A_Frog_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = Console.ReadLine().Split(' ');
            var N = int.Parse(l1[0]);
            var K = int.Parse(l1[1]);
            
            var hi = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            
            var costs = new long[N];
            costs[0] = 0;

            for(int i = 1;i <= K;i++)
            {
                costs[i] = Math.Abs(hi[0]-hi[i]);
                if(i==N-1) break;
            }

            for(int i = K+1;i<=N-1;i++)
            {
                costs[i] = long.MaxValue;
                for(int j= 1;j<=K;j++)
                {
                    costs[i] = Math.Min(costs[i],costs[i-j]+Math.Abs(hi[i]-hi[i-j]));
                }
            }

            Console.WriteLine(costs[N-1]);
        }
    }
}
