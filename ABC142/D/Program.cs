using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var gcd = GCD(AB[0], AB[1]);

            var isPrime = new bool[(int)Math.Sqrt(gcd) + 1];
            for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;
            isPrime[0] = false; isPrime[1] = false;
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i]) continue;
                for (int j = 2; i * j < isPrime.Length; j++) isPrime[i * j] = false;
            }

            var primefactor = new List<int>();
            for (int i = 2; i <= Math.Sqrt(gcd); i++)
            {
                if (!isPrime[i]) continue;
                if (gcd % i != 0) continue;
                primefactor.Add(i);
                while (gcd % i == 0) gcd /= i;
            }
            if (gcd != 1) primefactor.Add((int)gcd);
            Console.WriteLine(primefactor.Count + 1);
        }

        static long GCD(long A, long B)
        {
            if (B > A) return GCD(B, A);
            if (A % B == 0)
            {
                return B;
            }
            else
            {
                return GCD(B, A % B);
            }
        }
    }
}
