using System;

namespace D___Gathering_Children
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var result = new int[S.Length];
            var countR = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'R') countR++;
                if (S[i] == 'L')
                {
                    result[i] += countR / 2;
                    result[i - 1] += countR / 2;
                    if ((countR % 2) == 1) result[i - 1] += 1;
                    countR = 0;
                }
            }
            var countL = 0;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] == 'L') countL++;
                if (S[i] == 'R')
                {
                    result[i] += countL / 2;
                    result[i + 1] += countL / 2;
                    if ((countL % 2) == 1) result[i + 1] += 1;
                    countL = 0;
                }
            }
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
