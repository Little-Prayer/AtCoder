using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "APPROVED" : "DENIED");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            foreach (int a in A)
            {
                if ((a % 2) == 0)
                {
                    if (((a % 3) != 0) && ((a % 5) != 0)) return false;
                }

            }
            return true;
        }
    }
}
