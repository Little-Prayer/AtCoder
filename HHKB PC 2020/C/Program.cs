using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var check = new int[N + 1];
            for (int i = 0; i < N; i++) if (P[i] <= N) check[P[i]]++;
            var current = 0;
            for (int i = 0; i <= N; i++)
            {
                if (check[i] == 0)
                {
                    current = i;
                    break;
                }
            }
            var result = new int[N];
            result[N - 1] = current;
            for (int i = N - 1; i > 0; i--)
            {
                if (P[i] < current)
                {
                    check[P[i]]--;
                    if (check[P[i]] == 0) current = P[i];
                }
                result[i - 1] = current;
            }
            for (int i = 0; i < N; i++) Console.WriteLine(result[i]);
        }
    }
}