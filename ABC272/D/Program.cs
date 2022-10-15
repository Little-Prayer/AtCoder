using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var map = new int[N][];
            for (int i = 0; i < N; i++) map[i] = new int[N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) map[i][j] = int.MaxValue - 1;
            map[0][0] = 0;

            var moves = new List<(int x, int y)>();
            for (int i = 0; i <= Math.Sqrt(M); i++)
            {
                for (int j = i; j <= Math.Sqrt(M); j++)
                {
                    if (i * i + j * j == M) moves.Add((i, j));
                }
            }
            var queue = new Queue<(int row, int column)>();
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var move in moves)
                {
                    if (current.row + move.x < N && current.column + move.y < N)
                    {
                        if (map[current.row + move.x][current.column + move.y] > map[current.row][current.column] + 1)
                        {
                            map[current.row + move.x][current.column + move.y] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row + move.x, current.column + move.y));
                        }
                    }
                    if (current.row + move.y < N && current.column + move.x < N)
                    {
                        if (map[current.row + move.y][current.column + move.x] > map[current.row][current.column] + 1)
                        {
                            map[current.row + move.y][current.column + move.x] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row + move.y, current.column + move.x));
                        }
                    }

                    if (current.row - move.x >= 0 && current.column + move.y < N)
                    {
                        if (map[current.row - move.x][current.column + move.y] > map[current.row][current.column] + 1)
                        {
                            map[current.row - move.x][current.column + move.y] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row - move.x, current.column + move.y));
                        }
                    }
                    if (current.row - move.y >= 0 && current.column + move.x < N)
                    {
                        if (map[current.row - move.y][current.column + move.x] > map[current.row][current.column] + 1)
                        {
                            map[current.row - move.y][current.column + move.x] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row - move.y, current.column + move.x));
                        }
                    }

                    if (current.row - move.x >= 0 && current.column - move.y >= 0)
                    {
                        if (map[current.row - move.x][current.column - move.y] > map[current.row][current.column] + 1)
                        {
                            map[current.row - move.x][current.column - move.y] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row - move.x, current.column - move.y));
                        }
                    }
                    if (current.row - move.y >= 0 && current.column - move.x >= 0)
                    {
                        if (map[current.row - move.y][current.column - move.x] > map[current.row][current.column] + 1)
                        {
                            map[current.row - move.y][current.column - move.x] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row - move.y, current.column - move.x));
                        }
                    }

                    if (current.row + move.x < N && current.column - move.y >= 0)
                    {
                        if (map[current.row + move.x][current.column - move.y] > map[current.row][current.column] + 1)
                        {
                            map[current.row + move.x][current.column - move.y] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row + move.x, current.column - move.y));
                        }
                    }
                    if (current.row + move.y < N && current.column - move.x >= 0)
                    {
                        if (map[current.row + move.y][current.column - move.x] > map[current.row][current.column] + 1)
                        {
                            map[current.row + move.y][current.column - move.x] = map[current.row][current.column] + 1;
                            queue.Enqueue((current.row + move.y, current.column - move.x));
                        }
                    }
                }
            }
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) if (map[i][j] == int.MaxValue - 1) map[i][j] = -1;
            for (int i = 0; i < N; i++) Console.WriteLine(string.Join(" ", map[i]));
        }
    }
}
