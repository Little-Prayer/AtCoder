using System;

namespace AGC020_B___Ice_Rink_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static string solver()
        {
            var K = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            if (A[K - 1] != 2) return "-1";

            long max = 3;
            long min = 2;
            for (int i = K - 2; i >= 0; i--)
            {
                if (A[i] > max) return "-1";
                max = max / A[i] * A[i] + A[i] - 1;
                min = ((min - 1) / A[i] + 1) * A[i];
            }
            return min < max ? $"{min} {max}" : "-1";
        }
    }
}
