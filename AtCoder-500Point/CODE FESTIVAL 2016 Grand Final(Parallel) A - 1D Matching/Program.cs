using System;

namespace CODE_FESTIVAL_2016_Grand_Final_Parallel__A___1D_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            long MOD = 1000000007;

            var computers = new int[N];
            for (int i = 0; i < N; i++) computers[i] = int.Parse(Console.ReadLine());
            Array.Sort(computers);

            var powers = new int[N];
            for (int i = 0; i < N; i++) powers[i] = int.Parse(Console.ReadLine());
            Array.Sort(powers);

            var isPower = new bool[2 * N];
            var p = 0; var c = 0;
            for (int i = 0; i < 2 * N; i++)
            {
                if (p == N)
                {
                    isPower[i] = false;
                    continue;
                }
                if (c == N)
                {
                    isPower[i] = true;
                    continue;
                }

                if (powers[p] < computers[c])
                {
                    isPower[i] = true;
                    p++;
                }
                else
                {
                    isPower[i] = false;
                    c++;
                }
            }

            long match = 1;
            var pow = 0; var comp = 0;
            for (int i = 0; i < 2 * N; i++)
            {
                if (isPower[i])
                {
                    if (pow < comp) match = match * (comp - pow) % MOD;
                    pow++;
                }
                else
                {
                    if (comp < pow) match = match * (pow - comp) % MOD;
                    comp++;
                }
            }
            Console.WriteLine(match);
        }
    }
}
