using System;
using System.Linq;

namespace D___Flipping_Signs
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var An = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            var DP = new long[N,2];
            DP[1,0] = An[0]+An[1];
            DP[1,1] = -An[0]-An[1];

            for(int i = 2 ; i < N ; i++)
            {
                DP[i,0] = Math.Max(DP[i-1,0],DP[i-1,1])+An[i];
                DP[i,1] = Math.Max(DP[i-1,0]-2*An[i-1]-An[i],DP[i-1,1]+2*An[i-1]-An[i]);
            }
        Console.WriteLine(Math.Max(DP[N-1,0],DP[N-1,1]));
        }
    }
}
