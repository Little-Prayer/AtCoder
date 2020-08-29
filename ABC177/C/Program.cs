using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var MOD = 1000000007L;

            var sum = A.Sum();
            sum %= MOD;
            var result = 0L;
            for (int i = 0; i < N - 1; i++)
            {
                sum -= A[i];
                if (sum < 0) sum += MOD;
                result += A[i] * sum;
                result %= MOD;
            }

            Console.WriteLine(result);
        }
    }
}
