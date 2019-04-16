using System;
using System.Linq;

namespace A_Frog_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var hi = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            var costs = new int[N];
            costs[0] = 0;
            costs[1] = Math.Abs(hi[0]-hi[1]);

            for(int i=2;i<=N-1;i++)
            {
                costs[i] = Math.Min(costs[i-2]+Math.Abs(hi[i-2]-hi[i]),costs[i-1]+Math.Abs(hi[i-1]-hi[i]));
            }
            Console.WriteLine(costs[N-1]);
        }
    }
}
