using System;
using System.Linq;

namespace ABC137_C___Green_Bin
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var strs = new string[N];
            for (int i = 0; i < N; i++) strs[i] = Console.ReadLine();
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };
            var strs2 = new long[N];
            for (int i = 0; i < N; i++)
            {
                strs2[i] = 1;
                for (int j = 0; j < strs[i].Length; j++)
                {
                    strs2[i] *= primes[strs[i][j] - 'a'];
                }
            }

            strs2 = strs2.OrderBy(n => n).ToArray();
            long result = 0;
            long count = 1;
            for (int i = 1; i < N; i++)
            {
                if (strs2[i] == strs2[i - 1])
                {
                    count++;
                }
                else
                {
                    result += count * (count - 1) / 2;
                    count = 1;
                }
            }
            result += count * (count - 1) / 2;
            Console.WriteLine(result);
        }

    }
}
