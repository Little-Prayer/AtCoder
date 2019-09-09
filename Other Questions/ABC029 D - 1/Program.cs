using System;

namespace ABC029_D___1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = Console.ReadLine();
            var DP = new long[N.Length + 1, 10, 11, 2];
            DP[0, 0, 0, 1] = 1;
            for (int digit = 1; digit <= N.Length; digit++)
            {
                int lastMax = N[digit - 1] - '0';
                for (int count = 0; count < 10; count++)
                {
                    for (int previous = 0; previous < 10; previous++)
                    {
                        if (lastMax == 1) DP[digit, lastMax, count + 1, 1] += DP[digit - 1, previous, count, 1];
                        else DP[digit, lastMax, count, 1] += DP[digit - 1, previous, count, 1];

                        for (int last = 0; last < 10; last++)
                        {
                            if (last == 1) DP[digit, last, count + 1, 0] += DP[digit - 1, previous, count, 0];
                            else DP[digit, last, count, 0] += DP[digit - 1, previous, count, 0];

                            if (last < lastMax)
                            {
                                if (last == 1) DP[digit, last, count + 1, 0] += DP[digit - 1, previous, count, 1];
                                else DP[digit, last, count, 0] += DP[digit - 1, previous, count, 1];
                            }
                        }
                    }
                }
            }

            long result = 0;
            for (int count = 1; count < 11; count++)
            {
                for (int last = 0; last < 10; last++)
                {
                    for (int isMax = 0; isMax < 2; isMax++)
                    {
                        result += DP[N.Length, last, count, isMax] * count;
                    }
                }
            }
            return result;
        }
    }
}
