using System;
using System.Linq;

namespace ABC133_D___Rain_Flows_into_Dams
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var sumRainfall = Ai.Sum();
            var rainFall = new long[N];

            rainFall[0] = sumRainfall;
            for (int i = 1; i < N; i += 2)
                rainFall[0] -= Ai[i] * 2;


            for (int i = 1; i < N; i++)
                rainFall[i] = 2 * Ai[i - 1] - rainFall[i - 1];

            Console.WriteLine(string.Join(" ", rainFall));
        }
    }
}
