using System;
using System.Linq;
using System.Collections.Generic;

namespace ARC087_D___FT_Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var s = Console.ReadLine();
            var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var x = xy[0];
            var y = xy[1];

            var moveX = new List<int>();
            var moveY = new List<int>();
            var isX = true;
            var moveCount = 0;
            foreach (char c in s)
            {
                if (c == 'T')
                {
                    if (isX) moveX.Add(moveCount); else moveY.Add(moveCount);
                    isX = !isX;
                    moveCount = 0;
                }
                if (c == 'F') moveCount++;
            }
            if (isX) moveX.Add(moveCount); else moveY.Add(moveCount);
            var start = moveX[0];
            moveX.RemoveAt(0);
            var differenceX = moveX.Sum() - Math.Abs(x - start);
            var differenceY = moveY.Sum() - Math.Abs(y);
            if (differenceX < 0 || differenceY < 0) return false;
            if ((differenceX % 2) == 1 || (differenceY % 2) == 1) return false;

            var dpX = new bool[10000, moveX.Count + 1];
            for (int i = 0; i < 8000 + 1; i++) for (int j = 0; j < moveX.Count + 1; j++) dpX[i, j] = false;
            dpX[0, 0] = true;
            for (int move = 1; move < moveX.Count + 1; move++)
            {
                for (int sum = 0; sum < 8000 + 1; sum++)
                {
                    if (dpX[sum, move - 1])
                    {
                        dpX[sum, move] = true;
                        dpX[sum + moveX[move - 1], move] = true;
                    }
                }
            }

            var dpY = new bool[10000, moveY.Count + 1];
            for (int i = 0; i < 8000 + 1; i++) for (int j = 0; j < moveY.Count + 1; j++) dpY[i, j] = false;
            dpY[0, 0] = true;
            for (int move = 1; move < moveY.Count + 1; move++)
            {
                for (int sum = 0; sum < 8000 + 1; sum++)
                {
                    if (dpY[sum, move - 1])
                    {
                        dpY[sum, move] = true;
                        dpY[sum + moveY[move - 1], move] = true;
                    }
                }
            }

            return dpX[differenceX / 2, moveX.Count] && dpY[differenceY / 2, moveY.Count];
        }
    }
}
