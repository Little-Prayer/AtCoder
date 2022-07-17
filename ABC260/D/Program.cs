using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var result = new int[N + 1];
            for (int i = 0; i < N + 1; i++) result[i] == -1;

        }
    }
}
