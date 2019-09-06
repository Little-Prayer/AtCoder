using System;

namespace ARC098_D___Xor_Sum_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var totalSum = new long[N + 1];
            var totalXor = new long[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                totalSum[i] = totalSum[i - 1] + A[i - 1];
                totalXor[i] = totalXor[i - 1] ^ A[i - 1];
            }

            long right = 1; long left = 1;
            long result = 0;
            while (right <= N)
            {
                if ((totalSum[right] - totalSum[left - 1]) == (totalXor[right] ^ totalXor[left - 1]))
                {
                    result += right - left + 1;
                    right++;
                }
                else
                {
                    left++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
