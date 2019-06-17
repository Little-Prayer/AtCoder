using System;

namespace E___Common_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var S = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var T = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            var DP = new int[S.Length+1,T.Length+1];
            DP[0,0] = 0;

            for(int s = 0 ; s < S.Length;s++)
            {
                for(int t = 0 ;t < T.Length;t++)
                {
                    if(S[s] == T[t])DP[s+1,t+1] = Math.Max(DP[s+1,t+1],DP[s,t] + 1);
                    DP[s+1,t+1] = Math.Max(DP[s+1,t],DP[s+1,t+1]);
                    DP[s+1,t+1] = Math.Max(DP[s,t+1],DP[s+1,t+1]);
                }
            }
            Console.WriteLine(DP[S.Length,T.Length]+1);
        }
    }
}

