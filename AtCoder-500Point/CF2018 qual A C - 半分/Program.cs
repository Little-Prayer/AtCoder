using System;

namespace CF2018_qual_A_C___半分
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long MOD = 1000000007;

            var logA = new int[N];
            for (int i = 0; i < N; i++)
            {
                while (A[i] > 0)
                {
                    A[i] /= 2;
                    logA[i]++;
                }
            }

            var DP = new long[N + 1, 5000, 2];
            DP[0, 0, 0] = 1;
            for (int number = 1; number < N + 1; number++)
            {
                for (int prevStep = 0; prevStep < 4000; prevStep++)
                {
                    for (int currentStep = 0; currentStep < logA[number - 1]; currentStep++)
                    {
                        DP[number, prevStep + currentStep, 0] += DP[number - 1, prevStep, 0];
                        DP[number, prevStep + currentStep, 0] %= MOD;
                    }

                    DP[number, prevStep + logA[number - 1], 1] += DP[number - 1, prevStep, 0];
                    DP[number, prevStep + logA[number - 1], 1] %= MOD;

                    for (int currentStep = 0; currentStep <= logA[number - 1]; currentStep++)
                    {
                        DP[number, prevStep + currentStep, 1] += DP[number - 1, prevStep, 1];
                        DP[number, prevStep + currentStep, 1] %= MOD;
                    }
                }
            }

            long result = 0;
            if (K < 5000) result += DP[N, K, 0] % MOD;
            for (int i = 0; i <= Math.Min(K, 4999); i++)
            {
                result += DP[N, i, 1];
                result %= MOD;
            }
            return result;
        }
    }
}
