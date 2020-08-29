using System;
using System.Linq;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var filterMax = (int)Math.Sqrt(A.Max());
            var filter = new bool[filterMax + 1];
            for (int i = 0; i < filterMax + 1; i++) filter[i] = true;
            var filterCount = new int[A.Max() + 1];

            for (int i = 0; i < N; i++)
            {
                if (A[i] > filterMax) filterCount[A[i]]++;
            }

            for (int i = 2; i <= filterMax; i++)
            {
                if (!filter[i]) continue;

                for (int j = 0; j < N; j++)
                {
                    if ((A[j] % i) == 0)
                    {
                        filterCount[i]++;
                        if (filterMax < (A[j] / i))
                            filterCount[A[j] / i]++;
                    }
                }

                for (int k = i; k <= filterMax; k += i) filter[k] = false;
            }


            if (filterCount.Max() == N) Console.WriteLine("not coprime");
            else if (filterCount.Max() > 1) Console.WriteLine("setwise coprime");
            else Console.WriteLine("pairwise coprime");
        }
    }
}
