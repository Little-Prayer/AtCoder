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
            if (S.Length != 8) return false;
            if (!((S[0] >= 'A') && (S[0] <= 'Z'))) return false;
            if (!((S[1] >= '1') && (S[1] <= '9'))) return false;
            for (int i = 2; i <= 6; i++) { if (!((S[i] >= '0') && (S[i] <= '9'))) return false; }
            if (!((S[7] >= 'A') && (S[7] <= 'Z'))) return false;
            return true;
        }
    }
}
