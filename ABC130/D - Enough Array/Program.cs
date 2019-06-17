using System;
using System.Linq;

namespace D___Enough_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = NK[0];
            var K = NK[1];

            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var acum = new long[N+1];
            acum[0] = 0;
            for(int i = 1 ; i < N+1 ; i++) acum[i] = acum[i-1] + Ai[i-1];

            var result = new long[N+1];
            var lead = 0;
            var follow = 0;
            for(;lead < N+1 ; lead++)
            {
                if(acum[lead] - acum[follow] < K)continue;
                for(;follow < lead && acum[lead] - acum[follow]>=K;follow++) result[follow] = N + 1 - lead;
            }
            Console.WriteLine(result.Sum());
        }
    }
}
