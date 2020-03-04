using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var strArray = new int[N + 1, 26];
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    strArray[i, j] = strArray[i - 1, j];
                    if (S[i - 1] == 'a' + j) strArray[i, j]++;
                }
            }
            var Q = int.Parse(Console.ReadLine());
            var query = new List<int[]>();
        }
    }
}
