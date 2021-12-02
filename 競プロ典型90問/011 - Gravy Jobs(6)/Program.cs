using System;
using System.Collections.Generic;
using System.Linq;

namespace _011___Gravy_Jobs_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var jobs = new List<Job>();

            for (int i = 0; i < N; i++)
            {
                var dcs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                jobs.Add(new Job(dcs[0], dcs[1], dcs[2]));
            }

            jobs = jobs.OrderBy(j => j.deadline).ToList();

            var DP = new long[N + 1, 5000 + 1];
            for (int i = 1; i < N + 1; i++)
            {
                for (int day = 1; day < 5000 + 1; day++)
                {
                    if (jobs[i - 1].deadline < day || day < jobs[i - 1].time)
                    {
                        DP[i, day] = Math.Max(DP[i - 1, day], DP[i, day - 1]);
                        continue;
                    }
                    DP[i, day] = Math.Max(DP[i - 1, day], DP[i - 1, day - jobs[i - 1].time] + jobs[i - 1].incentive);
                }
            }
            Console.WriteLine(DP[N, 5000]);
        }
    }
    public class Job
    {
        public int deadline { get; }
        public int time { get; }
        public int incentive { get; }

        public Job(int d, int c, int s)
        {
            deadline = d;
            time = c;
            incentive = s;
        }
    }
}