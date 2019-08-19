using System;
using System.Collections.Generic;
using System.Text;

namespace ABC109_D___Make_Them_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var map = new int[HW[0] + 1, HW[1] + 1];
            var oddPoints = new Queue<Point>();
            for (int i = 0; i < HW[0]; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < HW[1]; j++)
                {
                    map[i + 1, j + 1] = read[j];
                    if (read[j] % 2 == 1) oddPoints.Enqueue(new Point(i + 1, j + 1));
                }
            }

            var moveCount = 0;
            var moveLog = new StringBuilder();
            while (oddPoints.Count > 1)
            {
                var from = oddPoints.Dequeue();
                var to = oddPoints.Dequeue();
                if (from.x < to.x)
                {
                    for (int i = from.x; i < to.x; i++)
                    {
                        moveLog.AppendLine($"{from.y} {i} {from.y} {i + 1}");
                        moveCount += 1;
                    }
                }
                else
                {
                    for (int i = from.x; i > to.x; i--)
                    {
                        moveLog.AppendLine($"{from.y} {i} {from.y} {i - 1}");
                        moveCount += 1;
                    }
                }

                if (from.y < to.y)
                {
                    for (int i = from.y; i < to.y; i++)
                    {
                        moveLog.AppendLine($"{i} {to.x} {i + 1} {to.x}");
                        moveCount += 1;
                    }
                }
                else
                {
                    for (int i = from.y; i > to.y; i--)
                    {
                        moveLog.AppendLine($"{i} {to.x} {i - 1} {to.x}");
                        moveCount += 1;
                    }
                }
            }
            Console.WriteLine(moveCount);
            Console.WriteLine(moveLog.ToString());
        }
    }
    struct Point
    {
        public int x;
        public int y;

        public Point(int _y, int _x)
        {
            x = _x;
            y = _y;
        }
    }
}
