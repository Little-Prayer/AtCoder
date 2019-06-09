using System;
using System.Collections.Generic;

namespace C___Typical_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var M = read[1];
            var MOD = 1000000007;
            
            var broken = new bool[N+1];
            for(int i = 0 ; i < N+1 ; i++) broken[i] = false;
            for(int i = 0 ; i < M ; i++)
            {
                var A = int.Parse(Console.ReadLine());
                broken[A] = true;
            }      

            var steps = new long[N+1];
            steps[0] = 1;
            steps[1] = broken[1] ? 0 : 1;
            for(int i = 2 ; i < N+1 ; i++)
            {
                if(broken[i])
                {
                    steps[i] = 0;
                }else
                {
                    steps[i] = (steps[i-1]+steps[i-2]) % MOD;
                }
            }

            Console.WriteLine(steps[N]);
        }
    }
}
