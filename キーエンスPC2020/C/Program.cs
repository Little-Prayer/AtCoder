using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKS = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NKS[0]; var K = NKS[1]; var S = NKS[2];
            var A = new int[N];
            for (int i = 0; i < K; i++) A[i] = S;
            for (int i = K; i < N; i++) A[i] = (S == 1000000000 ? S - 1 : S + 1);
            Console.WriteLine(string.Join(" ", A));
        }
    }
}
