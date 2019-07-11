using System;
using System.Linq;

namespace D___Rain_Flows_into_Dams
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var rainfall = new long[N];
            var sumRainfall = Ai.Sum() / 2;

            for (int i = 0; i < N; i++)
            {
                rainfall[i] = sumRainfall;
                for (int j = 0; j < N; j += 2)
                {
                    rainfall[i] -= Ai[(i + j) % N];
                }
                rainfall[i] *= -2;
            }
            var strrf = rainfall.Select(s => s.ToString()).ToArray();
            Console.WriteLine(string.Join(" ", strrf));
        }
    }
}
