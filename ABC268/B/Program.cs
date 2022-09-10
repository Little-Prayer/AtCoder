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
            var S = Console.ReadLine();
            var T = Console.ReadLine();
            if (S.Length > T.Length) return false;

            for (int i = 0; i < S.Length; i++) if (S[i] != T[i]) return false;
            return true;
        }
    }
}
