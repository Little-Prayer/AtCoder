using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            if (N % 2 == 1) return false;
            for (int i = 0; i < N / 2; i++) if (S[i] != S[i + N / 2]) return false;
            return true;
        }
    }
}
