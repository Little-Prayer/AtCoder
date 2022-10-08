using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            var routes = new long[M + 1, 3];
            for (int i = 1; i <= M; i++)
            {
                var abc = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                routes[i, 0] = abc[0];
                routes[i, 1] = abc[1];
                routes[i, 2] = abc[2];
            }

            var cities = new long[N + 1];
            for (int i = 2; i <= N; i++) cities[i] = -1;
            var sequence = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            foreach (int current in sequence)
            {
                if (cities[routes[current, 0]] >= 0 && (cities[routes[current, 1]] > cities[routes[current, 0]] + routes[current, 2] || cities[routes[current, 1]] < 0))
                    cities[routes[current, 1]] = cities[routes[current, 0]] + routes[current, 2];
            }
            Console.WriteLine(cities[N]);
        }
    }
}
