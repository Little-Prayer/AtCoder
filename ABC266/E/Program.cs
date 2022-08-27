using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            double recursion(int N)
            {
                if (N == 1) return 3.5;
                double ex = 0;
                var currentRec = recursion(N - 1);
                for (int i = 1; i <= 6; i++) ex += (Math.Max(i, currentRec));
                return ex / 6;
            }
            Console.WriteLine(recursion(N));
        }
    }
}
