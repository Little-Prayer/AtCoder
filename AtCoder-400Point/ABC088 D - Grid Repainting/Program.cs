using System;
using System.Collections.Generic;

namespace ABC088_D___Grid_Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var height = HW[0];
            var width = HW[1];
            var map = new int[width, height];
            var wallCount = 0;
            for (int i = 0; i < height; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    map[j, i] = read[j] == '#' ? -1 : 0;
                    wallCount -= map[j, i];
                }
            }

            var searchQueue = new Queue<Point>();
            searchQueue.Enqueue(new Point(0, 0));
            while (searchQueue.Count != 0)
            {
                var current = searchQueue.Dequeue();
                var currentSteps = map[current.x, current.y];
                if (current.x != 0 && map[current.x - 1, current.y] == 0)
                {
                    map[current.x - 1, current.y] = currentSteps + 1;
                    searchQueue.Enqueue(new Point(current.x - 1, current.y));
                }
                if (current.x != width - 1 && map[current.x + 1, current.y] == 0)
                {
                    map[current.x + 1, current.y] = currentSteps + 1;
                    searchQueue.Enqueue(new Point(current.x + 1, current.y));
                }
                if (current.y != 0 && map[current.x, current.y - 1] == 0)
                {
                    map[current.x, current.y - 1] = currentSteps + 1;
                    searchQueue.Enqueue(new Point(current.x, current.y - 1));
                }
                if (current.y != height - 1 && map[current.x, current.y + 1] == 0)
                {
                    map[current.x, current.y + 1] = currentSteps + 1;
                    searchQueue.Enqueue(new Point(current.x, current.y + 1));
                }
            }
            var minSteps = map[width - 1, height - 1];
            Console.WriteLine(minSteps == 0 ? -1 : height * width - wallCount - minSteps - 1);
        }
    }
    struct Point
    {
        public int x;
        public int y;
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
