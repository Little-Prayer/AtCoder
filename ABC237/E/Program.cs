using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var H = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var link = new List<int>[N + 1];
            for (int i = 1; i < N + 1; i++) link[i] = new List<int>();


        }
    }
}
