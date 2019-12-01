using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long MOD = 1000000007;

            long result = 1;
            var colorCount = new int[3];
            for (int i = 0; i < N; i++)
            {
                if (A[i] == colorCount[0] && A[i] == colorCount[1] && A[i] == colorCount[2])
                {
                    result *= 3;
                    result %= MOD;
                    colorCount[0]++;
                }
                else if (A[i] == colorCount[0] && A[i] == colorCount[1])
                {
                    result *= 2;
                    result %= MOD;
                    colorCount[0]++;
                }
                else if (A[i] == colorCount[1] && A[i] == colorCount[2])
                {
                    result *= 2;
                    result %= MOD;
                    colorCount[1]++;
                }
                else if (A[i] == colorCount[0])
                {
                    colorCount[0]++;
                }
                else if (A[i] == colorCount[1])
                {
                    colorCount[1]++;
                }
                else if (A[i] == colorCount[2])
                {
                    colorCount[2]++;
                }
                else result = 0;
            }
            Console.WriteLine(result);
        }
    }
}
