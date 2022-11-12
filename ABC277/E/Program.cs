using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            var connectionA = new List<int>[N + 1];
            var connectionB = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                connectionA[i] = new List<int>();
                connectionB[i] = new List<int>();
            }
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                if (read[2] == 1)
                {
                    connectionA[read[0]].Add(read[1]);
                    connectionA[read[1]].Add(read[0]);
                }
                else
                {
                    connectionB[read[0]].Add(read[1]);
                    connectionB[read[1]].Add(read[0]);
                }
            }
            var S = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var sw = new Dictionary<int, int>();
            for (int i = 0; i < K; i++) sw.Add(S[i], 0);
            var moveA = new int[N + 1];
            var moveB = new int[N + 1];
            for (int i = 0; i <= N; i++)
            {
                moveA[i] = int.MaxValue;
                moveB[i] = int.MaxValue;
            }
            moveA[1] = 0;
            var que = new Queue<(int point, bool route)>();
            que.Enqueue((1, true));
            while (que.Count > 0)
            {
                var current = que.Dequeue();
                if (current.route)
                {
                    foreach (var r in connectionA[current.point])
                    {
                        if (moveA[r] > moveA[current.point])
                        {
                            moveA[r] = moveA[current.point] + 1;
                            que.Enqueue((r, true));
                        }
                    }
                    if (sw.ContainsKey(current.point))
                    {
                        moveB[current.point] = moveA[current.point];
                        foreach (var r in connectionB[current.point])
                        {
                            if (moveB[r] > moveB[current.point])
                            {
                                moveB[r] = moveB[current.point] + 1;
                                que.Enqueue((r, false));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var r in connectionB[current.point])
                    {
                        if (moveB[r] > moveB[current.point])
                        {
                            moveB[r] = moveB[current.point] + 1;
                            que.Enqueue((r, false));
                        }
                    }
                    if (sw.ContainsKey(current.point))
                    {
                        moveA[current.point] = moveB[current.point];
                        foreach (var r in connectionA[current.point])
                        {
                            if (moveA[r] > moveA[current.point])
                            {
                                moveA[r] = moveA[current.point] + 1;
                                que.Enqueue((r, true));
                            }
                        }
                    }
                }
            }
            if (moveA[N] == int.MaxValue) moveA[N] = -1;
            Console.WriteLine(moveA[N]);
        }
    }
}

