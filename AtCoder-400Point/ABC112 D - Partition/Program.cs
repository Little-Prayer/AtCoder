using System;

namespace ABC112_D___Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];
            for (int i = N; i <= M / 2; i++)
            {
                if (M % i == 0) return M / i;
            }
            return 1;
        }
    }
}
