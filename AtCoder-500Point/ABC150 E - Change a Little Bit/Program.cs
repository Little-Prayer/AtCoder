using System;
using System.Linq;

namespace ABC150_E___Change_a_Little_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            C = C.OrderByDescending(n => n).ToArray();
            long MOD = 1000000007;

            var result = 0L;
            for (int i = 0; i < N; i++)
            {
                long temp1 = (C[i] * modPow(2, N - i - 1, MOD)) % MOD;
                long temp2 = (temp1 * ((modPow(2, i, MOD) % MOD) + (modPow(2, i - 1, MOD) * i) % MOD)) % MOD;
                result += temp2;
                result %= MOD;
            }
            result *= modPow(2, N, MOD);
            result %= MOD;
            Console.WriteLine(result);
        }
        static long modPow(long a, long n, long mod)
        {
            long result = 1;
            while (n > 0)
            {
                if ((n & 1) > 0) result = result * a % mod;
                a = a * a % mod;
                n >>= 1;
            }
            return result;
        }
    }
}

