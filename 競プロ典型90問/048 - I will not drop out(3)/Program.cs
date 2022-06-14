using System;
using System.Collections.Generic;
using System.Linq;

namespace _048___I_will_not_drop_out_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = new List<long>();
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                A.Add(read[0] - read[1]);
                A.Add(read[1]);
            }

            Console.WriteLine(A.OrderByDescending(n => n).Take(K).Sum());
        }
    }
}
