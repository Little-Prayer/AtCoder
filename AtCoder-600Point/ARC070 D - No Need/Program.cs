using System;
using System.Linq;

namespace ARC070_D___No_Need
{
    class Program
    {
        static int N;
        static int K;
        static int[] ai;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            N = NK[0]; K = NK[1];
            ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            ai = ai.Where(n => n < K).OrderBy(s => s).ToArray();

            int left = -1;
            int right = ai.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (DP(mid)) right = mid;
                else left = mid;
            }

            Console.WriteLine(right);
        }
        static bool DP(int mid)
        {
            var DP = new bool[ai.Length + 1, 2 * K];
            DP[0, 0] = true;
            for (int i = 1; i < ai.Length + 1; i++)
            {
                var item = i - 1 != mid ? ai[i - 1] : 0;
                for (int k = 0; k < K; k++)
                {
                    if (k < item) DP[i, k] = DP[i - 1, k];
                    else DP[i, k] = DP[i - 1, k] || DP[i - 1, k - item];
                }
            }
            for (int i = K - ai[mid]; i < K; i++) if (DP[ai.Length, i]) return true;
            return false;
        }
    }
}
