using System;
using System.Linq;

namespace ARC063_D___高橋君と見えざる手
{
    class Program
    {
        static void Main(string[] args)
        {
            var NT = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NT[0];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var income = new long[N];
            var min = A[0];
            for (int i = 1; i < N; i++)
            {
                income[i] = A[i] - min;
                if (A[i] < min) min = A[i];
            }

            var maxIncome = income.Max();
            Console.WriteLine(income.Count(i => i == maxIncome));
        }
    }
}
