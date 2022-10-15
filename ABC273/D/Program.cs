using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static int lower_bound(int ng, int ok, Func<int, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                int mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
        static void Main(string[] args)
        {
            var HWcs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HWcs[0]; var W = HWcs[1]; var Row = HWcs[2]; var Column = HWcs[3];
            var wallHorizontal = new Dictionary<int, List<int>>();
            var wallVertical = new Dictionary<int, List<int>>();
            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var rc = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var r = rc[0]; var c = rc[1];
                if (wallHorizontal.ContainsKey(r))
                {
                    wallHorizontal[r].Add(c);
                }
                else
                {
                    var tempList = new List<int>();
                    tempList.Add(0);
                    tempList.Add(W + 1);
                    tempList.Add(c);
                    wallHorizontal.Add(r, tempList);
                }
                if (wallVertical.ContainsKey(c))
                {
                    wallVertical[c].Add(r);
                }
                else
                {
                    var tempList = new List<int>();
                    tempList.Add(0);
                    tempList.Add(H + 1);
                    tempList.Add(r);
                    wallVertical.Add(c, tempList);
                }
            }
            var keysHorizontal = wallHorizontal.Keys.ToArray();
            foreach (int key in keysHorizontal)
            {
                wallHorizontal[key] = wallHorizontal[key].OrderBy(n => n).ToList();
            }
            var keysVertical = wallVertical.Keys.ToArray();
            foreach (int key in keysVertical)
            {
                wallVertical[key] = wallVertical[key].OrderBy(n => n).ToList();
            }

            var Q = int.Parse(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                var dl = Console.ReadLine().Split(" ");
                var direction = dl[0]; var length = int.Parse(dl[1]);
                if (direction == "U")
                {
                    if (wallVertical.ContainsKey(Column))
                    {
                        var walls = wallVertical[Column];

                        var wall = lower_bound(walls.Count(), -1, (num => walls[num] < Row));
                        Row = Math.Max(Row - length, walls[wall] + 1);

                    }
                    else
                    {
                        Row = Math.Max(Row - length, 1);
                    }

                }
                if (direction == "D")
                {
                    if (wallVertical.ContainsKey(Column))
                    {
                        var walls = wallVertical[Column];
                        var wall = lower_bound(-1, walls.Count(), (num => walls[num] > Row));
                        Row = Math.Min(Row + length, walls[wall] - 1);
                    }
                    else
                    {
                        Row = Math.Min(Row + length, H);
                    }

                }
                if (direction == "L")
                {
                    if (wallHorizontal.ContainsKey(Row))
                    {
                        var walls = wallHorizontal[Row];

                        var wall = lower_bound(walls.Count(), -1, (num => walls[num] < Column));
                        Column = Math.Max(Column - length, walls[wall] + 1);

                    }
                    else
                    {
                        Column = Math.Max(Column - length, 1);
                    }

                }
                if (direction == "R")
                {
                    if (wallHorizontal.ContainsKey(Row))
                    {
                        var walls = wallHorizontal[Row];
                        var wall = lower_bound(-1, walls.Count(), (num => walls[num] > Column));
                        Column = Math.Min(Column + length, walls[wall] - 1);
                    }
                    else
                    {
                        Column = Math.Min(Column + length, W);
                    }
                }
                Console.WriteLine($"{Row} {Column}");
            }

        }
    }
}
