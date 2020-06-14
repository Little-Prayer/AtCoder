using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static List<int> A2;
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            A2 = A.OrderBy(n => n).ToList();

            var result = 0;
            foreach (int a in A) if (check(a)) result++;
            Console.WriteLine(result);
        }
        static bool check(int a)
        {
            var count = 0;
            if (A2.BinarySearch(a) + 1 != A2.Count && A2[A2.BinarySearch(a) + 1] == a) return false;
            for (int i = 1; i <= Math.Sqrt(a); i++)
            {
                if ((a % i) == 0)
                {
                    if (A2.BinarySearch(i) >= 0) count++;
                    if (A2.BinarySearch(a / i) >= 0) count++;
                }
            }
            return count == 1;
        }
    }
}
