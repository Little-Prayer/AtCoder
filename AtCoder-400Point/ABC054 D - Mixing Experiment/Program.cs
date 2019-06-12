using System;

namespace ABC054_D___Mixing_Experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = read[0];
            var Ma = read[1];
            var Mb = read[2];

            var Mmax = N * 10 + 1;

            var costs = new int[Mmax, Mmax];
            for (int i = 0; i < Mmax; i++) for (int j = 0; j < Mmax; j++) costs[i, j] = int.MaxValue;
            costs[0, 0] = 0;

            for (int i = 0; i < N; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var a = read[0];
                var b = read[1];
                var c = read[2];

                for (int j = Mmax - 1; j >= 0; j--)
                {
                    for (int k = Mmax - 1; k >= 0; k--)
                    {
                        if (costs[j, k] != int.MaxValue) costs[j + a, k + b] = Math.Min(costs[j + a, k + b], costs[j, k] + c);
                    }
                }
            }

            var result = int.MaxValue;
            decimal ratio = (decimal)Ma / (decimal)Mb;

            for (int i = 1; i < Mmax; i++) for (int j = 1; j < Mmax; j++) if ((decimal)i / (decimal)j == ratio) result = Math.Min(result, costs[i, j]);

            if (result == int.MaxValue) result = -1;

            Console.WriteLine(result);
        }
    }
}
