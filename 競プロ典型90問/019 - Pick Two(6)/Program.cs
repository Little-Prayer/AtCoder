using System;

namespace _019___Pick_Two_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var DP = new int[2 * N, 2 * N];
            for (int i = 1; i < 2 * N; i++) DP[i - 1, i] = Math.Abs(A[i] - A[i - 1]);

            for (int distance = 3; distance < 2 * N; distance += 2)
            {
                for (int left = 0; left + distance < 2 * N; left++)
                {
                    var right = left + distance;
                    var temporary = DP[left + 1, right - 1] + Math.Abs(A[left] - A[right]);
                    for (int mid = left + 1; mid < right; mid += 2) temporary = Math.Min(temporary, DP[left, mid] + DP[mid + 1, right]);
                    DP[left, right] = temporary;
                }
            }
            Console.WriteLine(DP[0, 2 * N - 1]);
        }
    }
}
