using System;
using System.Linq;

namespace AGC010_B___Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "YES" : "NO");
        }
        static bool solver()
        {
            var N = long.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var difference = new long[N];
            difference[0] = A[0] - A[N - 1];
            for (int i = 1; i < N; i++) difference[i] = A[i] - A[i - 1];

            if ((A.Sum() % (N * (N + 1) / 2) != 0)) return false;
            var opCount = A.Sum() / (N * (N + 1) / 2);
            for (int i = 0; i < N; i++)
            {
                var check = (difference[i] - opCount) * -1;
                if (check < 0 || check % N != 0) return false;
            }
            return true;
        }
    }
}
