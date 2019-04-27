using System;
using System.Linq;

namespace C___GCD_on_Blackboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            if(N == 2)
            {
                Console.WriteLine(Math.Max(A[0],A[1]));
            }else{

                var GCD = new long[N,2];
                
                GCD[2,0] = euclid(euclid(A[0],A[1]),A[2]);
                GCD[2,1] = Math.Max(Math.Max(euclid(A[0],A[1]),euclid(A[0],A[2])),euclid(A[1],A[2]));

                for(int i = 3 ; i < N ; i++)
                {
                    GCD[i,0] = euclid(GCD[i-1,0],A[i]);
                    GCD[i,1] = Math.Max(euclid(GCD[i-1,1],A[i]),GCD[i-1,0]);
                }

                Console.WriteLine(GCD[N-1,1]);
            }
        }
        
        static long euclid(long M,long N)
        {
            if(M<N)
            {
                return euclid(N,M);
            }
            while(N != 0)
            {
                var temp = M % N;
                M = N;
                N = temp;
            }
            return M;
        }
    }
}
