using System;
using System.Linq;
using System.Collections.Generic;

namespace ABC118_D___Match_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            var stroke = new int[] { 0, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).OrderByDescending(n => n).ToArray();

            var matches = new Dictionary<int, int>();
            foreach (int i in Ai)
            {
                if (matches.ContainsKey(stroke[i])) continue;
                matches.Add(stroke[i], i);
            }

            var DP = new String[NM[0] + 10];
            for (int i = 0; i < DP.Length; i++) DP[i] = "";
            foreach (int i in matches.Keys) DP[i] = matches[i].ToString();
            for (int i = 0; i < NM[0]; i++)
            {
                if (DP[i] != "")
                {
                    foreach (int j in matches.Keys)
                    {
                        var temp = DP[i] + matches[j].ToString();
                        if (temp.Length > DP[i + j].Length || (temp.Length == DP[i + j].Length && temp.CompareTo(DP[i + j]) > 0)) DP[i + j] = temp;
                    }
                }
            }
            Console.WriteLine(DP[NM[0]]);
        }
    }
}
