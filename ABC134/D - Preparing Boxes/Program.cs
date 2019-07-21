using System;
using System.Collections.Generic;

namespace D___Preparing_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var ai = new int[N + 1];
            for (int i = 1; i < N + 1; i++) ai[i] = read[i - 1];
            var bi = new int[N + 1];
            var M = 0;
            var output = new List<int>();
            for (int i = N; i > 0; i--)
            {
                bi[i] = ai[i];
                for (int j = 2; j * i <= N; j++)
                {
                    bi[i] ^= bi[j * i];
                }
                if (bi[i] == 1)
                {
                    M += 1;
                    output.Add(i);
                }
            }
            Console.WriteLine(M);
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
