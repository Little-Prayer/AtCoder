using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146_E___Rem_of_Sum_is_Num
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            if (K == 1) return 0;

            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var minus1A = A.Select(n => n - 1).ToArray();
            var accumA = new long[N + 1];
            accumA[0] = 0;
            for (int i = 1; i < N + 1; i++) accumA[i] = accumA[i - 1] + minus1A[i - 1];
            accumA = accumA.Select(n => n % K).ToArray();

            var dic = new Dictionary<long, long>();
            for (int i = 1; i < Math.Min(K, N + 1); i++)
            {
                if (dic.ContainsKey(accumA[i])) dic[accumA[i]] += 1;
                else dic.Add(accumA[i], 1);
            }

            var result = 0L;
            result += dic.ContainsKey(0) ? dic[0] : 0;
            for (int i = 1; i < N + 1; i++)
            {
                if (dic.ContainsKey(accumA[i])) dic[accumA[i]] -= 1;
                if (N >= i + K - 1)
                {
                    if (dic.ContainsKey(accumA[i + K - 1])) dic[accumA[i + K - 1]] += 1;
                    else dic.Add(accumA[i + K - 1], 1);
                }
                result += dic.ContainsKey(accumA[i]) ? dic[accumA[i]] : 0;
            }
            return result;
        }
    }
}
