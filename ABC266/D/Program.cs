using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var point = new long[100001, 5];

            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                point[read[0], read[1]] = read[2];
            }

            var DP = new long[100001, 5];
            for (int i = 0; i <= 4; i++) for (int j = 0; j <= 100000; j++) DP[j, i] = int.MinValue;
            DP[0, 0] = 0;
            for (int time = 1; time <= 100000; time++)
            {
                for (int position = 0; position <= 4; position++)
                {
                    if (position != 0) DP[time, position] = Math.Max(DP[time, position], DP[time - 1, position - 1] + point[time, position]);
                    DP[time, position] = Math.Max(DP[time, position], DP[time - 1, position] + point[time, position]);
                    if (position != 4) DP[time, position] = Math.Max(DP[time, position], DP[time - 1, position + 1] + point[time, position]);
                }
            }

            long result = 0;
            for (int i = 0; i <= 4; i++) result = Math.Max(result, DP[100000, i]);
            Console.WriteLine(result);
        }
    }
}
