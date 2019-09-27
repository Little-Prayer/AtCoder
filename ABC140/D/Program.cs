using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((solver()));
        }

        static int solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var S = Console.ReadLine();

            if (N == 1) return 0;

            var happiness = 0;
            if (S[0] == 'R' && S[1] == 'R') happiness++;
            if (S[N - 1] == 'L' && S[N - 2] == 'L') happiness++;
            for (int i = 1; i < N - 1; i++)
            {
                if (S[i] == 'L' && S[i - 1] == 'L') happiness++;
                if (S[i] == 'R' && S[i + 1] == 'R') happiness++;
            }
            return Math.Min(N - 1, happiness + 2 * K);
        }
    }
}
