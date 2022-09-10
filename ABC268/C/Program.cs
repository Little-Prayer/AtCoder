using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var pi = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var pi2 = new int[N];
            for (int i = 0; i < N; i++)
            {
                pi2[i] = pi[i] - i;
                if (pi2[i] < 0) pi2[i] += N;
            }
            var pi3 = new int[N];
            for (int i = 0; i < N; i++) pi3[pi2[i]]++;

            var result = pi3[0] + pi3[1] + pi3[2];
            var current = result;
            for (int i = 2; i < N - 1; i++)
            {
                current -= pi3[i - 2];
                current += pi3[i + 1];
                result = Math.Max(result, current);
            }
            result = Math.Max(result, (pi3[N - 2] + pi3[N - 1] + pi3[0]));
            result = Math.Max(result, (pi3[N - 1] + pi3[0] + pi3[1]));
            Console.WriteLine(result);
        }
    }
}
