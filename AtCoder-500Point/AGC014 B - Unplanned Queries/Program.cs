using System;

namespace AGC014_B___Unplanned_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve() ? "YES" : "NO");
        }
        static bool Solve()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var count = new int[N + 1];
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                count[ab[0]]++;
                count[ab[1]]++;
            }
            for (int i = 1; i < N + 1; i++)
            {
                if (count[i] % 2 == 1) return false;
            }
            return true;
        }
    }
}
