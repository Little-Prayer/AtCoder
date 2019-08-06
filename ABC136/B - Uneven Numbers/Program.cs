using System;

namespace B___Uneven_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            if (N < 10) return N;
            if (N < 100) return 9;
            if (N < 1000) return N - 90;
            if (N < 10000) return 909;
            if (N < 100000) return N - 9090;
            if (N == 100000) return 90909;
            return 90909;
        }
    }
}
