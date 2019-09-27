using System;
using System.Linq;

namespace Tenka1_2017_D___IntegerotS
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NK[0]; var K = NK[1];
            var A = new long[N]; var B = new long[N];
            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                A[i] = ab[0]; B[i] = ab[1];
            }

            var result = new long[31];
            for (int i = 29; i >= 0; i--)
            {
                if ((K & (1 << i)) > 0)
                {
                    for (int j = 0; j < N; j++)
                    {
                        var check = true;
                        for (int k = 29; k > i; k--)
                        {
                            if ((K & (1 << k)) - (A[j] & (1 << k)) < 0)
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check && (A[j] & (1 << i)) == 0) result[i] += B[j];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                if ((A[i] | K) == K) result[30] += B[i];
            }
            Console.WriteLine(result.Max());
        }
    }
}
