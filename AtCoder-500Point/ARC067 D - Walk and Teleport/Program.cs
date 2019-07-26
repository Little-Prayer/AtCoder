using System;

namespace ARC067_D___Walk_and_Teleport
{
    class Program
    {
        static void Main(string[] args)
        {
            var NAB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NAB[0];
            var A = NAB[1];
            var B = NAB[2];
            var Xi = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long result = 0;
            for (int i = 1; i < N; i++) result += Math.Min(B, (Xi[i] - Xi[i - 1]) * A);
            Console.WriteLine(result);
        }
    }
}
