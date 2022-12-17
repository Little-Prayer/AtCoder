using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NT = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NT[0]; var T = NT[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var loop = A.Sum();

            var reminder = T % loop;
            int count;
            for (count = 0; count < N; count++)
            {
                if (reminder < A[count]) break;

                reminder -= A[count];
            }
            Console.WriteLine($"{count + 1} {reminder}");
        }
    }
}
