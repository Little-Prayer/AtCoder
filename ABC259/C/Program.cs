using System;
using System.Collections.Generic;

namespace C
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

            List<(char c, int count)> comp(string str)
            {
                var result = new List<(char, int)>();
                (char c, int count) current = (str[0], 1);
                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == current.c)
                    {
                        current.count++;
                    }
                    else
                    {
                        result.Add(current);
                        current = (str[i], 1);
                    }
                }
                result.Add(current);
                return result;
            }
            var compS = comp(S);
            var compT = comp(T);
            if (compS.Count != compT.Count) return false;

            for (int i = 0; i < compS.Count; i++)
            {
                if (compS[i].c != compT[i].c) return false;

                if (compS[i].count == 1 && compT[i].count > 1) return false;

                if (compS[i].count > compT[i].count) return false;
            }
            return true;
        }
    }
}
