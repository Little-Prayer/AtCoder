using System;
using System.Collections.Generic;

namespace ABC114_D___756
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isPrime = new bool[N + 1];
            for (int i = 0; i < N + 1; i++) isPrime[i] = true;
            isPrime[0] = false;
            isPrime[1] = false;

            for (int i = 2; i < Math.Pow(N, 0.5); i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i + 1; j < N + 1; j++) if (j % i == 0) isPrime[j] = false;
            }

            var factoring = new Dictionary<int, int>();
            for (int i = 2; i < N + 1; i++) if (isPrime[i]) factoring.Add(i, 0);

            int[] primes = new int[factoring.Keys.Count];
            factoring.Keys.CopyTo(primes, 0);

            for (int i = 2; i <= N; i++)
            {
                foreach (int j in primes)
                {
                    var temp = j;
                    if (i < j) break;
                    while (i % temp == 0)
                    {
                        factoring[j] += 1;
                        temp *= j;
                    }
                }
            }

            var count2 = 0;
            var count4 = 0;
            var count14 = 0;
            var count24 = 0;
            var count74 = 0;

            foreach (int item in factoring.Values)
            {
                if (item >= 2) count2 += 1;
                if (item >= 4) count4 += 1;
                if (item >= 14) count14 += 1;
                if (item >= 24) count24 += 1;
                if (item >= 74) count74 += 1;
            }

            var result = 0;
            result += count4 * (count4 - 1) * (count2 - 2) / 2;
            result += count14 * (count4 - 1);
            result += count24 * (count2 - 1);
            result += count74;
            Console.WriteLine(result);
        }
    }
}
