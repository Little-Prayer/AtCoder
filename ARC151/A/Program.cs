using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static string solver()
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            var countAll = 0;
            var countS = 0;
            var countT = 0;
            for (int i = 0; i < N; i++)
            {
                if (S[i] != T[i])
                {
                    countAll++;
                    if (S[i] == '1') countS++;
                    else countT++;
                }
            }

            if ((countAll % 2) == 1) return "-1";

            var result = new char[N];
            if (countS > countT)
            {
                var diff = (countS - countT) / 2;
                for (int i = N - 1; i >= 0; i--)
                {
                    if (S[i] != T[i] && S[i] == '1' && diff > 0)
                    {
                        diff--;
                        result[i] = '1';
                    }
                    else
                    {
                        result[i] = '0';
                    }
                }
            }
            else
            {
                var diff = (countT - countS) / 2;
                for (int i = N - 1; i >= 0; i--)
                {
                    if (S[i] != T[i] && T[i] == '1' && diff > 0)
                    {
                        diff--;
                        result[i] = '1';
                    }
                    else
                    {
                        result[i] = '0';
                    }
                }
            }
            return new string(result);
        }
    }

}
