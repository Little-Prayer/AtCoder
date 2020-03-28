using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NXY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NXY[0]; var X = NXY[1]; var Y = NXY[2];
            var distance = new int[N + 1, N + 1];
            var distanceCount = new int[N];
            for (int i = 1; i < N; i++)
            {
                for (int j = i + 1; j < N + 1; j++)
                {
                    distance[i, j] = Math.Min(j - i, Math.Min(Math.Abs(i - X) + Math.Abs(j - Y) + 1, Math.Abs(j - X) + Math.Abs(i - Y) + 1));
                    distanceCount[distance[i, j]]++;
                }
            }
            for (int i = 1; i < N; i++) Console.WriteLine(distanceCount[i]);
        }
    }
}
