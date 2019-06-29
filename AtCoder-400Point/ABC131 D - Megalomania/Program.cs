using System;
using System.Linq;

namespace ABC131_D___Megalomania
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var works = new Work[N];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                works[i] = new Work(read[0], read[1]);
            }

            works = works.OrderBy(w => w.limit).ToArray();
            bool canFinish = true;
            long workingTime = 0;

            foreach (Work w in works)
            {
                workingTime += w.time;
                if (workingTime > w.limit)
                {
                    canFinish = false;
                    break;
                }
            }

            Console.WriteLine(canFinish ? "Yes" : "No");
        }
    }
    class Work
    {
        public long time;
        public long limit;

        public Work(long _time, long _limit)
        {
            time = _time;
            limit = _limit;
        }
    }
}
