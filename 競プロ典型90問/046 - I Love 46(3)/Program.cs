using System;

namespace _046___I_Love_46_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var modA = new long[46];
            foreach (int a in A) modA[a % 46]++;

            var modB = new long[46];
            foreach (int b in B) modB[b % 46]++;

            var modC = new long[46];
            foreach (int c in C) modC[c % 46]++;

            long result = 0;
            for (long a = 0; a < 46; a++)
                for (long b = 0; b < 46; b++)
                    for (long c = 0; c < 46; c++)
                        if (((a + b + c) % 46) == 0) result += modA[a] * modB[b] * modC[c];

            Console.WriteLine(result);
        }
    }
}
