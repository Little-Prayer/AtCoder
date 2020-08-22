using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var start = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var goal = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var map = new bool[H, W];

            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < W; j++)
                {
                    map[i, j] = (read[j] == '.');
                }
            }

            var warp = new int[H, W];
            var isCheck = new bool[H, W];
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) warp[i, j] = int.MaxValue;
            warp[start[0] - 1, start[1] - 1] = 0;
            isCheck[start[0] - 1, start[1] - 1] = true;

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((start[0] - 1, start[1] - 1));
            var walls = new Queue<(int x, int y)>();
            var warpCount = 0;
            while (walls.Count > 0 || queue.Count > 0)
            {
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (current.x > 0)
                    {
                        if (map[current.x - 1, current.y])
                        {
                            if (!isCheck[current.x - 1, current.y])
                            {
                                warp[current.x - 1, current.y] = warpCount;
                                queue.Enqueue((current.x - 1, current.y));
                            }
                        }
                        else
                        {
                            if (!isCheck[current.x - 1, current.y])
                                walls.Enqueue((current.x - 1, current.y));
                        }
                        isCheck[current.x - 1, current.y] = true;
                    }
                    if (current.y > 0)
                    {
                        if (map[current.x, current.y - 1])
                        {
                            if (!isCheck[current.x, current.y - 1])
                            {
                                warp[current.x, current.y - 1] = warpCount;
                                queue.Enqueue((current.x, current.y - 1));
                            }
                        }
                        else
                        {
                            if (!isCheck[current.x, current.y - 1])
                                walls.Enqueue((current.x, current.y - 1));
                        }
                        isCheck[current.x, current.y - 1] = true;
                    }
                    if (current.x < H - 1)
                    {
                        if (map[current.x + 1, current.y])
                        {
                            if (!isCheck[current.x + 1, current.y])
                            {
                                warp[current.x + 1, current.y] = warpCount;
                                queue.Enqueue((current.x + 1, current.y));
                            }
                        }
                        else
                        {
                            if (!isCheck[current.x + 1, current.y])
                                walls.Enqueue((current.x + 1, current.y));
                        }
                        isCheck[current.x + 1, current.y] = true;
                    }
                    if (current.y < W - 1)
                    {
                        if (map[current.x, current.y + 1])
                        {
                            if (!isCheck[current.x, current.y + 1])
                            {
                                warp[current.x, current.y + 1] = warpCount;
                                queue.Enqueue((current.x, current.y + 1));
                            }
                        }
                        else
                        {
                            if (!isCheck[current.x, current.y + 1])
                                walls.Enqueue((current.x, current.y + 1));
                        }
                        isCheck[current.x, current.y + 1] = true;
                    }
                }
                while (walls.Count > 0)
                {
                    var current = walls.Dequeue();
                    for (int x = Math.Max(0, current.x - 1); x <= Math.Min(H - 1, current.x + 1); x++)
                    {
                        for (int y = Math.Max(0, current.y - 1); y <= Math.Min(W - 1, current.y + 1); y++)
                        {
                            if (map[x, y] && !isCheck[x, y])
                            {
                                warp[x, y] = warpCount + 1;
                                queue.Enqueue((x, y));
                                isCheck[x, y] = true;
                            }
                        }
                    }

                }
                warpCount++;
            }
            Console.WriteLine(warp[goal[0] - 1, goal[1] - 1] < int.MaxValue ? warp[goal[0] - 1, goal[1] - 1] : -1);
        }
    }
}