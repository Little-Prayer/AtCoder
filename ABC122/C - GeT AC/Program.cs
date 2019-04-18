using System;
using System.Linq;

namespace C___GeT_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            var Read = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int N = Read[0];
            int Q = Read[1];

            string S = Console.ReadLine();

            //1文字めからi文字めまでの"AC"の登場回数の累積
            int[] Accumulation = new int[N+1];

            Accumulation[1] = 0;

            for(int i = 2 ; i <= N ; i++)
            {
                Accumulation[i] = Accumulation[i-1];
                if(S[i-1]== 'C')
                {
                    if(S[i-2] == 'A')
                    {
                        Accumulation[i] = Accumulation[i-1]+1;
                    }
                }
            }

            for(int i = 0 ; i < Q ; i++)
            {
                Read = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                int L = Read[0];
                int R = Read[1];
                Console.WriteLine(Accumulation[R]-Accumulation[L]);
            }
 
        }
    }
}
