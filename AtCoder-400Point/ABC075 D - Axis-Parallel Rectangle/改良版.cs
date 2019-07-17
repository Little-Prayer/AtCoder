using System;
using System.Linq;

namespace ABC075_D___Axis_Parallel_Rectangle改善
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];

            var points = new Point[N];
            for (int i = 0; i < N; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                points[i] = new Point(xy[0], xy[1]);
            }

            var projectionX = points.Select(p => p.x).OrderBy(x => x).ToArray();
            var projectionY = points.Select(p => p.y).OrderBy(y => y).ToArray();

            var cumlative = new int[N + 1, N + 1];
            foreach (Point p in points)
            {
                cumlative[Array.BinarySearch(projectionX, p.x) + 1, Array.BinarySearch(projectionY, p.y) + 1] += 1;
            }
            for (int x = 1; x < N + 1; x++)
            {
                for (int y = 1; y < N + 1; y++)
                {
                    cumlative[x, y] += cumlative[x, y - 1];
                }
            }
            for (int y = 1; y < N + 1; y++)
            {
                for (int x = 1; x < N + 1; x++)
                {
                    cumlative[x, y] += cumlative[x - 1, y];
                }
            }
            long minArea = long.MaxValue;
            for (int L = 1; L < N + 1; L++)
            {
                for (int B = 1; B < N + 1; B++)
                {
                    for (int T = B + 1; T < N + 1; T++)
                    {
                        for (int R = L + 1; R < N + 1; R++)
                        {
                            if ((cumlative[R, T] - cumlative[R, B - 1] - cumlative[L - 1, T] + cumlative[L - 1, B - 1]) >= K)
                            {
                                minArea = Math.Min(minArea, (projectionX[R - 1] - projectionX[L - 1]) * (projectionY[T - 1] - projectionY[B - 1]));
                            }
                        }
                    }
                }
            }
            Console.WriteLine(minArea);
        }
    }

    struct Point
    {
        public long x;
        public long y;

        public Point(long _x, long _y)
        {
            x = _x;
            y = _y;
        }

    }
}
