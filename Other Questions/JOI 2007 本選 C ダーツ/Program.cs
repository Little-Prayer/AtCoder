using System;
using System.Linq;
using System.Collections.Generic;

namespace JOI_2007_本選_C_ダーツ
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var point = new int[N + 1];
            for (int i = 1; i < N + 1; i++) point[i - 1] = int.Parse(Console.ReadLine());

            var point2 = new List<int>();
            for (int i = 0; i < N + 1; i++)
            {
                for (int j = 1; j < N + 1; j++)
                {
                    point2.Add(point[i] + point[j]);
                }
            }
            point2 = point2.OrderByDescending(p => p).ToList();

            var result = 0;
            foreach (int p in point2)
            {
                if (p > M) continue;
                var after = lower_bound(point2, M - p);
                result = Math.Max(result, p + point2[after]);
            }
            Console.WriteLine(result);
        }

        static int lower_bound(List<int> list, int key)
        {
            int left = -1; int right = list.Count;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] <= key) right = mid;
                else left = mid;
            }
            return right;
        }
    }
}
