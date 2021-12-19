using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NX[0]; var X = NX[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(solver(X, 1));

            long solver(long amount, int current)
            {
                if (current == N) return 0;
                var small = A[current - 1];
                var large = A[current];
                var subamount = amount % large;
                if (subamount / small < (large - subamount) / small + 1)
                    return subamount / small + solver(amount - subamount, current + 1);
                else return (large - subamount) / small + solver(amount - subamount + large, current + 1);
            }

        }
    }
}
