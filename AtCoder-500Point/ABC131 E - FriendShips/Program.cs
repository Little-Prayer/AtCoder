using System;
using System.Text;

namespace ABC131_E___FriendShips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static string solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];

            if (K > (N - 1) * (N - 2) / 2) return "-1";

            var graph = new StringBuilder();
            graph.AppendLine((N - 1 + ((N - 1) * (N - 2) / 2 - K)).ToString());
            for (int i = 2; i <= N; i++) graph.AppendLine($"1 {i}");

            var counter = 0;
            for (int i = 2; i < N; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    if (K == (N - 1) * (N - 2) / 2 - counter) return graph.ToString().TrimEnd('\r', '\n');
                    graph.AppendLine($"{i} {j}");
                    counter += 1;
                }
            }
            return graph.ToString().TrimEnd('\r', '\n');
        }
    }
}