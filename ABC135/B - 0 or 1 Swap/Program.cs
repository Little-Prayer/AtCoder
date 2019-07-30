using System;

namespace B___0_or_1_Swap
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var pi = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var count = 0;
            for (int i = 0; i < N; i++) if (pi[i] != i + 1) count++;
            Console.WriteLine(count <= 2 ? "YES" : "NO");
        }
    }
}
