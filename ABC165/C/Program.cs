using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMQ[0]; var M = NMQ[1]; var Q = NMQ[2];
            var query = new int[Q, 4];
            for (int i = 0; i < Q; i++)
            {
                var abcd = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                query[i, 0] = abcd[0];
                query[i, 1] = abcd[1];
                query[i, 2] = abcd[2];
                query[i, 3] = abcd[3];
            }

        }
    }
}
