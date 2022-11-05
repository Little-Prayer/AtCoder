using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var sieve = new bool[(int)Math.Sqrt(A.Max()) + 1];
            for (int i = 2; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }
            for (int i = 2; i < sieve.Length; i++)
            {
                if (!sieve[i]) continue;
                for (int j = 2; j * i < sieve.Length; j++) sieve[j * i] = false;
            }

            var prime = new List<int>();
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i]) prime.Add(i);
            }

            foreach (int p in prime)
            {
                while (A.Where(n => (n % p) == 0).Count() == N)
                {
                    for (int i = 0; i < N; i++)
                    {
                        A[i] /= p;
                    }
                }
            }
            var s = A[0];
            while ((s % 2) == 0) s /= 2;
            while ((s % 3) == 0) s /= 3;
            if (A.Where(n => (n % s) == 0).Count() == N)
            {
                for (int i = 0; i < N; i++) A[i] /= s;
            }

            var count = 0;
            for (int j = 0; j < N; j++)
            {

                while (A[j] > 1)
                {
                    if ((A[j] % 2) == 0)
                    {
                        count++;
                        A[j] /= 2;
                    }
                    if ((A[j] % 3) == 0)
                    {
                        count++;
                        A[j] /= 3;
                    }
                    if (((A[j] % 2) != 0) && ((A[j] % 3) != 0) && A[j] != 1) return -1;
                }
            }
            return count;
        }
    }
}
