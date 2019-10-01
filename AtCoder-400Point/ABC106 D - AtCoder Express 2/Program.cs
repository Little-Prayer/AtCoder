using System;

namespace ABC106_D___AtCoder_Express_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMQ[0]; var M = NMQ[1]; var Q = NMQ[2];
            var connection = new int[N + 1, N + 1];
            for (int i = 0; i < M; i++)
            {
                var LR = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[LR[0], LR[1]]++;
            }
            var accum = new int[N + 1, N + 1];
            for (int l = 0; l < N; l++)
            {
                for (int r = 0; r < N; r++)
                {
                    accum[l + 1, r + 1] = accum[l + 1, r] + accum[l, r + 1] - accum[l, r] + connection[l + 1, r + 1];
                }
            }

            for (int i = 0; i < Q; i++)
            {
                var pq = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var p = pq[0]; var q = pq[1];
                var result = accum[q, q] - accum[p - 1, q] - accum[q, p - 1] + accum[p - 1, p - 1];
                Console.WriteLine(result);
            }
        }
    }
}
