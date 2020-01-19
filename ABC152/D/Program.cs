using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var MOD = 1000000007;
            var A = 12345678900000;
            var b = 100000;
            A %= MOD;
            Console.WriteLine(A * modinv(b, MOD) % MOD);
        }
        static long modinv(long a, long mod)
        {
            long b = mod;
            long u = 1;
            long v = 0;
            while (b != 0)
            {
                long t = a / b;
                a -= t * b;
                var temp1 = a;
                a = b;
                b = temp1;
                u -= t * v;
                var temp2 = u;
                u = v;
                v = temp2;
            }
            u %= mod;
            if (u < 0) u += mod;
            return u;
        }

        static long LCM(long A, long B)
        {
            var gcd = GCD(A, B);
            var temp = A / gcd;
            return temp * B;
        }

        static long GCD(long A, long B)
        {
            if (A < B)
                return GCD(B, A);
            while (B != 0)
            {
                var remainder = A % B;
                A = B;
                B = remainder;
            }
            return A;
        }
    }
}
