using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Q = int.Parse(Console.ReadLine());

            for (int i = 0; i < Q; i++)
            {
                var query = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (query[0] == 1)
                {
                    A[query[1] - 1] = query[2];
                }
                else
                {
                    Console.WriteLine(A[query[1]-1]);
                }
            }
        }
    }
}
