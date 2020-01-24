using System;
using System.Collections.Generic;
using System.Linq;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var MOD = 1000000007;
            var searchPrime = 1000;

            var isPrime = new bool[searchPrime + 1];
            for (int i = 2; i < searchPrime + 1; i++) isPrime[i] = true;
            for (int i = 2; i < searchPrime + 1; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i + 1; j < searchPrime + 1; j++)
                    {
                        if ((j % i) == 0) isPrime[j] = false;
                    }
                }
            }

            var primeFactor = new Dictionary<int, int>();
            for (int i = 0; i < searchPrime; i++)
            {
                if (isPrime[i]) primeFactor.Add(i, 0);
            }

            var primes = primeFactor.Keys.ToArray();
            foreach (int ai in A)
            {
                var temp = ai;
                foreach (int prime in primes)
                {
                    if (temp == 1) break;
                    var count = 0;
                    while ((temp % prime) == 0)
                    {
                        temp /= prime;
                        count++;
                    }
                    if (primeFactor[prime] < count) primeFactor[prime] = count;
                }
                if (!primeFactor.ContainsKey(temp)) primeFactor.Add(temp, 1);
            }

            var lcd = 1L;
            foreach (int prime in primeFactor.Keys)
            {
                for (int i = 0; i < primeFactor[prime]; i++)
                {
                    lcd *= prime;
                    lcd %= MOD;
                }
            }

            var result = 0L;
            foreach (int ai in A)
            {
                result += (lcd * modinv(ai, MOD)) % MOD;
                result %= MOD;
            }
            Console.WriteLine(result);
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
    }
}
