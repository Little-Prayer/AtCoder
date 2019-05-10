using System;
using System.Collections.Generic;
using System.Linq;

namespace C___One_stroke_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var M = read[1];

            var nodes = new List<int>[N+1];
            for(int i = 1 ; i < N+1 ; i++) nodes[i] = new List<int>();

            for(int j = 0 ; j < M ; j++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            }
        }
    }
}
