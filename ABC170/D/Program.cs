using System;
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
            Array.Sort(A);
            if (N == 1) return 1;
            if (A[1] == 1) return 0;
            if (A[0] == 1) return 1;

            var Amax = A[N - 1];
            var check = new bool[Amax + 1];
            for (int i = 0; i < Amax + 1; i++) check[i] = true;
            for (int i = 0; i < N; i++)
            {
                if (!check[A[i]]) continue;
                for (int j = 2 * A[i]; j < Amax + 1; j += A[i]) check[j] = false;
            }
            var result = new bool[N];
            for (int i = 0; i < N; i++)
            {
                if (i + 1 < N && A[i] == A[i + 1])
                {
                    result[i] = false;
                    result[i + 1] = false;
                    check[A[i]] = false;
                }
                else
                {
                    result[i] = check[A[i]];
                }
            }
            return result.Count(r => r);
        }
    }
}