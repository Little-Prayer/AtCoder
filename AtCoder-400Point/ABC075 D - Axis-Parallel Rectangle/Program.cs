using System;
using System.Linq;

namespace ABC075_D___Axis_Parallel_Rectangle
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

            points = points.OrderBy(p => p.x).ToArray();
            var projectionX = points.Select(p => p.x).OrderBy(x => x).ToArray();
            var projectionY = points.Select(p => p.y).OrderBy(y => y).ToArray();
            var minArea = long.MaxValue;

            for (int L = 0; L < N; L++)
            {
                for (int B = 0; B < N; B++)
                {
                    for (int R = L + 1; R < N; R++)
                    {
                        for (int T = B + 1; T < N; T++)
                        {
                            var containPoints = 0;
                            foreach (Point p in points)
                            {
                                if (p.x > projectionX[R]) break;
                                if (p.x >= projectionX[L] && p.x <= projectionX[R] && p.y >= projectionY[B] && p.y <= projectionY[T])
                                {
                                    containPoints += 1;
                                }
                            }
                            if (containPoints >= K) minArea = Math.Min(minArea, (projectionX[R] - projectionX[L]) * (projectionY[T] - projectionY[B]));
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
