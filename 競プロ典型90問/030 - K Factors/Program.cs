using System;
using System.Linq;

namespace _030___K_Factors
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var divisor = new int[NK[0] + 1];

            for (int i = 2; i < NK[0] + 1; i++)
            {
                if (divisor[i] > 0) continue;
                for (int j = i; j <= NK[0]; j += i) divisor[j]++;
            }
            Console.WriteLine(divisor.Count(n => n >= NK[1]));
        }
    }
}
