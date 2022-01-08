using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var xy = new double[N, 2];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                xy[i, 0] = read[0]; xy[i, 1] = read[1];
            }
            double result = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    result = Math.Max(Math.Sqrt((xy[i, 0] - xy[j, 0]) * (xy[i, 0] - xy[j, 0]) + (xy[i, 1] - xy[j, 1]) * (xy[i, 1] - xy[j, 1])), result);
                }
            }
            Console.WriteLine(result);
        }
    }
}
