using System;
using System.Collections.Generic;

namespace B___Good_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            var ND = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var points = new List<int[]>();
            for (int i = 0; i < ND[0]; i++) points.Add(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));

            var result = 0;
            for (int i = 0; i < ND[0]; i++)
            {
                for (int j = i + 1; i < ND[0]; i++)
                {
                    double sum = 0;
                    for (int k = 0; k < ND[1]; k++)
                    {
                        sum += Math.Pow(points[i][k] - points[j][k], 2.0);
                    }
                    Console.WriteLine(sum);
                    var sq = Math.Sqrt(Math.Abs(sum));
                    if ((int)sq == sq) result += 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
