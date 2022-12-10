using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = new long[N];
            A[0] = S[0];
            for (int i = 1; i < N; i++)
            {
                var temp = 0L;
                for (int j = 0; j < i; j++) { temp += A[j]; }
                A[i] = S[i] - temp;
            }
            Console.WriteLine(string.Join(" ", A));
        }
    }
}
