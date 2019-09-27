using System;

namespace c
{
    class Program
    {
        static void Main(string[] args)
        {
            var NKQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NKQ[0]; var K = NKQ[1]; var Q = NKQ[2];

            var correct = new int[N + 1];
            for (int i = 0; i < Q; i++)
            {
                var A = int.Parse(Console.ReadLine());
                correct[A]++;
            }
            for (int i = 1; i < N + 1; i++)
            {
                Console.WriteLine(Q - correct[i] < K ? "Yes" : "No");
            }
        }
    }
}
