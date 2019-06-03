using System;
using System.Linq;

namespace B___ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var countAll = S.Replace("BC","D")
            .Split(new char[]{'B','C'},StringSplitOptions.RemoveEmptyEntries)
            .Select(s => countSwap(s))
            .Sum();
            
            Console.WriteLine(countAll);
        }

        static long countSwap(string S)
        {
            long countA = 0;
            long swap = 0;
            foreach(char c in S)
            {
                if(c == 'A') countA += 1;
                if(c == 'D') swap += countA;
            }

            return swap;
        }
    }
}
