using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var sum = A.Sum();
            var limit = (double)sum / (double)(4 * M);

            var get = 0;
            foreach (int a in A)
            {
                if ((double)a >= limit) get++;
            }
            Console.WriteLine(get >= M ? "Yes" : "No");
        }
    }
}
