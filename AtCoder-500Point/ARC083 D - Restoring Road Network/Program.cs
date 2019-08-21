using System;
using System.Linq;
using System.Collections.Generic;

namespace ARC083_D___Restoring_Road_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = int.Parse(Console.ReadLine());
            var distance = new long[N + 1, N + 1];
            long result = 0;
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                for (int j = 0; j < N; j++)
                {
                    distance[i + 1, j + 1] = read[j];
                    result += read[j];
                }
            }
            result /= 2;

            for (int from = 1; from < N + 1; from++)
            {
                for (int to = from + 1; to < N + 1; to++)
                {
                    var isDelete = false;
                    for (int via = 1; via < N + 1; via++)
                    {
                        if (via == from || via == to) continue;
                        var compare = distance[from, to].CompareTo(distance[from, via] + distance[via, to]);
                        if (compare > 0) return -1;
                        if (compare == 0) isDelete = true;
                    }
                    if (isDelete) result -= distance[from, to];
                }
            }
            return result;
        }
    }
}