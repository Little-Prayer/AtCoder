using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var R = 0L; var G = 0L; var B = 0L;
            for (int i = 0; i < N; i++)
            {
                if (S[i] == 'R') R++;
                if (S[i] == 'G') G++;
                if (S[i] == 'B') B++;
            }
            var result = R * G * B;
            for (int i = 0; i < N; i++)
            {
                for (int d = 1; i + 2 * d < N; d++)
                {
                    if (S[i] != S[i + d] && S[i + d] != S[i + 2 * d] && S[i] != S[i + 2 * d]) result--;
                }
            }
            Console.WriteLine(result);
        }
    }
}
