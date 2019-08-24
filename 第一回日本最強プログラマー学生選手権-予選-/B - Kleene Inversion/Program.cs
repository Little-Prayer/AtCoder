using System;

namespace B___Kleene_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0];
            var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var MOD = 1000000007;

            var invert = new long[N];
            for (int i = 0; i < N; i++) for (int j = i + 1; j < N; j++) if (A[i] > A[j]) invert[i]++;

            var lessCount = new long[N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) if (i != j && A[i] > A[j]) lessCount[i]++;

            long result = 0;
            for (int i = 0; i < N; i++)
            {
                result = (result + (invert[i] * K) % MOD) % MOD;
                result = (result + (lessCount[i] * ((K * K - K) / 2 % MOD)) % MOD) % MOD;
            }
            Console.WriteLine(result % MOD);
        }
    }
}