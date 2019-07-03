using System;

namespace ABC116_C___Grand_Garden
{
    class Program
    {
        static int[] garden;
        static void Main(string[] args)
        {
            Console.ReadLine();
            garden = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(watering(0, garden.Length - 1, 0));
        }

        static int watering(int left, int right, int bottom)
        {
            if (left == right) return garden[left] - bottom;

            int min = int.MaxValue;
            int minIndex = 0;
            for (int i = left; i <= right; i++)
            {
                if (garden[i] < min)
                {
                    min = garden[i];
                    minIndex = i;
                }
            }

            if (minIndex == left)
            {
                return watering(left + 1, right, min) + min - bottom;
            }
            else if (minIndex == right)
            {
                return watering(left, right - 1, min) + min - bottom;
            }
            else
            {
                return watering(left, minIndex - 1, min) + watering(minIndex + 1, right, min) + min - bottom;
            }
        }
    }
}
