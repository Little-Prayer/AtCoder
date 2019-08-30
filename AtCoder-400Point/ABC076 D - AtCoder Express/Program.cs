using System;
using System.Linq;

namespace ABC076_D___AtCoder_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var T = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var V = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var totalTime = T.Sum() * 2;

            var limits = new SpeedLimit[N + 2];
            limits[0] = new SpeedLimit(0, 0, 0);
            for (int i = 1; i < N + 1; i++) limits[i] = new SpeedLimit(limits[i - 1].End, limits[i - 1].End + T[i - 1] * 2, V[i - 1]);
            limits[N + 1] = new SpeedLimit(totalTime, totalTime, 0);

            var speed = new double[totalTime + 1];
            for (int t = 1; t <= totalTime; t++)
            {
                speed[t] = double.PositiveInfinity;
                foreach (SpeedLimit l in limits)
                {
                    if (l.Start > t)
                    {
                        speed[t] = Math.Min(speed[t], l.Limit + (l.Start - t) * 0.5);
                    }
                    else if (l.End < t)
                    {
                        speed[t] = Math.Min(speed[t], l.Limit + (t - l.End) * 0.5);
                    }
                    else
                    {
                        speed[t] = Math.Min(speed[t], l.Limit);
                    }
                }
            }

            double distance = 0;
            for (int i = 1; i < totalTime + 1; i++)
            {
                if (speed[i] > speed[i - 1])
                {
                    distance += speed[i - 1] * 0.5 + 0.125;
                }
                else if (speed[i] < speed[i - 1])
                {
                    distance += speed[i] * 0.5 + 0.125;
                }
                else
                {
                    distance += speed[i] * 0.5;
                }
            }
            Console.WriteLine(distance);
        }
        struct SpeedLimit
        {
            public double Start;
            public double End;
            public double Limit;
            public SpeedLimit(double _start, double _end, double _limit)
            {
                Start = _start;
                End = _end;
                Limit = _limit;
            }
        }
    }
}
