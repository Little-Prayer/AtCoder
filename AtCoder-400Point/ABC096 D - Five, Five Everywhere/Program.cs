using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC096_D___Five__Five_Everywhere
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isPrime = new bool[55556];
            for (int i = 2; i <= 55555; i++) isPrime[i] = true;
            for (int i = 2; i <= 55555; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i * 2; j <= 55555; j += i) isPrime[j] = false;
            }
            var primes = new List<int>();
            for (int i = 2; i <= 55555; i++) if (isPrime[i]) primes.Add(i);
            var answer = primes.Where(s => s % 5 == 1).Take(N).ToArray();
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
