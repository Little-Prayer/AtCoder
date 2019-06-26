using System;
using System.Collections.Generic;

namespace G___Longest_Path
{
    class Program
    {
        static List<int>[] connection;
        static int[] DP;
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];

            connection = new List<int>[N + 1];
            for (int i = 1; i < N + 1; i++) connection[i] = new List<int>();

            DP = new int[N + 1];
            for (int i = 0; i < N + 1; i++) DP[i] = -1;

            for (int i = 0; i < M; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[xy[0]].Add(xy[1]);
            }

            int result = 0;
            for (int i = 1; i < N + 1; i++) result = Math.Max(result, search(i));

            Console.WriteLine(result);
        }

        static int search(int currentNode)
        {
            if (DP[currentNode] != -1) return DP[currentNode];

            int result = 0;
            foreach (int nextNode in connection[currentNode])
                result = Math.Max(result, search(nextNode) + 1);

            return DP[currentNode] = result;
        }
    }
}
