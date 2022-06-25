using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NKQ[0]; var K = NKQ[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var L = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            foreach (int i in L)
            {
                if (A[i - 1] == N) continue;
                if (i != K && A[i - 1] + 1 == A[i]) continue;
                A[i - 1]++;
            }
            Console.WriteLine(string.Join(" ", A));
        }
    }
}