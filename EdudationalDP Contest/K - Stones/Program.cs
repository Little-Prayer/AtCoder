using System;

namespace K___Stones
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];
            var picks = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var DP = new bool[K + 1];
            for (int i = 0; i < K + 1; i++) DP[i] = false;

            for (int i = K; i >= 0; i--)
            {
                for (int j = 0; j < N && picks[j] <= K - i; j++)
                {
                    if (!DP[i + picks[j]])
                    {
                        DP[i] = true;
                        break;
                    }
                }
            }

            Console.WriteLine(DP[0] ? "First" : "Second");
        }
    }
}
