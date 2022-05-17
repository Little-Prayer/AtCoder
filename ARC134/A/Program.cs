using System;
using System.Collections.Generic;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NLW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NLW[0]; var L = NLW[1]; var W = NLW[2];
            var A = new List<long>(Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse));

            var result = 0L;
            if (A[A.Count - 1] != L - W)
            {
                result++;
                A.Add(L - W);
            }
            result += A[0] / W;
            if ((A[0] % W) > 0) result++;
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i - 1] + W >= A[i]) continue;
                result += (A[i] - A[i - 1] - W) / W;
                if (((A[i] - A[i - 1] - W) % W) > 0) result++;
            }
            Console.WriteLine(result);
        }
    }
}
