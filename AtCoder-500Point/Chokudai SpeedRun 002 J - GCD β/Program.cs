using System;
using System.Linq;
using System.Collections.Generic;

namespace Chokudai_SpeedRun_002_J___GCD_β
{
    class Program
    {
        static int[] A;
        static int[] B;
        static List<int> candidate;
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            A = new int[N]; B = new int[N];
            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                A[i] = ab[0]; B[i] = ab[1];
            }

            candidate = new List<int>();
            for (int i = 1; i <= Math.Sqrt(A[0]); i++)
            {
                if (A[0] % i == 0)
                {
                    candidate.Add(i);
                    candidate.Add(A[0] / i);
                }
            }
            for (int i = 1; i < Math.Sqrt(B[0]); i++)
            {
                if (B[0] % i == 0)
                {
                    candidate.Add(i);
                    candidate.Add(B[0] / i);
                }
            }
            candidate = candidate.Distinct().OrderBy(n => n).ToList();
            var result = 1;
            for (int i = 0; i < candidate.Count; i++)
            {
                if (isOK(candidate[i])) result = candidate[i];
            }
            Console.WriteLine(result);
        }

        static bool isOK(int key)
        {
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] % key != 0 && B[i] % key != 0) return false;
            }
            return true;
        }
    }
}
