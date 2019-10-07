using System;
using System.Collections.Generic;

namespace AGC039_B___Graph_Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static int solve()
        {
            var N = int.Parse(Console.ReadLine());
            var connection = new int[N + 1, N + 1];
            for (int i = 0; i < N; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    connection[i + 1, j + 1] = read[j] == '0' ? int.MaxValue : 1;
                    if (i == j) connection[i + 1, j + 1] = 0;
                }
            }

            var partition = new int[N + 1];
            partition[1] = 1;
            var queue = new Queue<int>();
            queue.Enqueue(1);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int next = 1; next < N + 1; next++)
                {
                    if (connection[current, next] != 1) continue;
                    if (partition[current] == partition[next]) return -1;
                    if (partition[next] == 0)
                    {
                        partition[next] = -partition[current];
                        queue.Enqueue(next);
                    }
                }
            }

            for (int via = 1; via < N + 1; via++)
            {
                for (int from = 1; from < N + 1; from++)
                {
                    for (int to = 1; to < N + 1; to++)
                    {
                        if (connection[from, via] == int.MaxValue || connection[via, to] == int.MaxValue) continue;
                        connection[from, to] = Math.Min(connection[from, to], connection[from, via] + connection[via, to]);
                    }
                }
            }

            var max = 0;
            for (int i = 1; i < N + 1; i++) for (int j = 1; j < N + 1; j++) max = Math.Max(max, connection[i, j]);
            return max + 1;
        }
    }
}
