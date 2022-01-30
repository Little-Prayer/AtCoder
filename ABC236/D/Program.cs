using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var C = new long[2 * N + 1, 2 * N + 1];
            for (int i = 1; i < 2 * N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                for (int j = 0; j < read.Length; j++)
                {
                    C[i, i + j + 1] = read[j];
                    C[i + j + 1, i] = read[j];
                }
            }
        }
    }
}
