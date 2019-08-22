using System;
using System.Linq;
using System.Collections.Generic;

namespace ARC088_D___Wide_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var S = Console.ReadLine();
            if (S.Length == 1) return 1;
            var result = S.Length;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] != S[i - 1]) result = Math.Min(result, Math.Max(i, S.Length - i));
            }
            return result;
        }
    }
}
