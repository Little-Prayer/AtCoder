using System;
using System.Linq;
using System.Collections.Generic;

namespace AGC002_C___Knot_Puzzle
{
    class Program
    {
        static List<int> process;
        static void Main(string[] args)
        {
            if (solver())
            {
                Console.WriteLine("Possible");
                foreach (int i in process) Console.WriteLine(i);
            }
            else Console.WriteLine("Impossible");

        }
        static bool solver()
        {
            var NL = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NL[0];
            var L = NL[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            int lastKnot;
            for (lastKnot = 1; lastKnot < N + 1; lastKnot++)
            {
                if (lastKnot == N) return false;
                if (A[lastKnot] + A[lastKnot - 1] >= L) break;
            }

            process = new List<int>();
            for (int i = 1; i < lastKnot; i++) process.Add(i);
            for (int i = (int)(N - 1); i > lastKnot; i--) process.Add(i);
            process.Add(lastKnot);
            return true;
        }
    }
}
