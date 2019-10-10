using System;

namespace ARC098_D___Xor_Sum_2_2回目_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var accumSum = new long[N + 1];
            for (int i = 1; i < N + 1; i++) accumSum[i] = accumSum[i - 1] + A[i - 1];
            var accumXor = new long[N + 1];
            for (int i = 1; i < N + 1; i++) accumXor[i] = accumXor[i - 1] ^ A[i - 1];

            var left = 1; var right = 1;
            long result = 0;
            while (left <= N)
            {
                if (right <= N && accumSum[right] - accumSum[left - 1] == (accumXor[right] ^ accumXor[left - 1]))
                {
                    right++;
                }
                else
                {
                    result += right - left;
                    left++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
