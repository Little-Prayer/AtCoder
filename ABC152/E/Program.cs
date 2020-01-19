using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var MOD = 1000000007;

            var lcd = 1;
            for (int i = 2; i <= 1000; i++)
            {
                var check = true;
                for (int j = 0; j < N; j++)
                {
                    if ((A[j] % i) != 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    lcd *= i;
                    lcd %= MOD;
                    for (int k = 0; k < N; k++) A[k] /= i;
                    Console.WriteLine(i);
                }
            }
            for (int i = 0; i < N; i++)
            {
                lcd *= A[i];
                lcd %= MOD;
            }
            Console.WriteLine(lcd);
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
