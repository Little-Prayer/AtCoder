using System;

namespace ABC089_D___Practical_Skill_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWD = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var maxNumber = HWD[0] * HWD[1];
            var D = HWD[2];
            var positions = new Point[maxNumber + 1];
            for (int j = 0; j < HWD[0]; j++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int i = 0; i < HWD[1]; i++) positions[read[i]] = new Point(i + 1, j + 1);
            }
            var moveCosts = new int[maxNumber + 1];
            for (int i = D + 1; i <= maxNumber; i++)
            {
                moveCosts[i] = moveCosts[i - D] + Math.Abs(positions[i].x - positions[i - D].x) + Math.Abs(positions[i].y - positions[i - D].y);
            }

            var Q = int.Parse(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                var LR = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(moveCosts[LR[1]] - moveCosts[LR[0]]);
            }
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
