using System;

namespace F
{
    class Program
    {
        static void Main(string[] args)
        {
            var NS = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NS[0]; var S = NS[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var MOD = 998244353;

            var DPL = new long[N + 1, N + 1, S + 1];
            DPL[0, 0, 0] = 1;
            for (int l = 1; l < N + 1; l++)
            {
                for (int i = 0; i <)
            }

        }
    }
}
