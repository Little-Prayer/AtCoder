using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC139_E___League
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var matches = new List<int>();
            var following = new Dictionary<int, List<int>>();
            var indegrees = new Dictionary<int, int>();
            var isRemaining = new Dictionary<int, bool>();
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = i + 1; j < N + 1; j++)
                {
                    var match = MatchHash(i, j);
                    matches.Add(match);
                    following.Add(match, new List<int>());
                    indegrees.Add(match, 0);
                    isRemaining.Add(match, true);
                }
            }

            for (int i = 1; i < N + 1; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 1; j < N - 1; j++)
                {
                    var prev = MatchHash(i, read[j - 1]);
                    var follow = MatchHash(i, read[j]);
                    following[prev].Add(follow);
                    indegrees[follow]++;
                }
            }

            var dailyMatches = new Queue<int>();
            foreach (int m in matches.Where(m => indegrees[m] == 0 && isRemaining[m])) dailyMatches.Enqueue(m);
            var day = 0;
            while (true)
            {
                var nextDayMatches = new Queue<int>();
                while (dailyMatches.Count() > 0)
                {
                    var current = dailyMatches.Dequeue();
                    isRemaining[current] = false;
                    foreach (int m in following[current])
                    {
                        indegrees[m]--;
                        if (indegrees[m] == 0) nextDayMatches.Enqueue(m);
                    }
                }
                day++;
                dailyMatches = nextDayMatches;
                if (dailyMatches.Count() == 0) break;
            }

            Console.WriteLine(isRemaining.Values.Count(m => m) > 0 ? -1 : day);
        }
        static int MatchHash(int A, int B)
        {
            return A > B ? A * 1000 + B : B * 1000 + A;
        }
    }
}
