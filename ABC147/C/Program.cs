using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            int[][] target = new int[N][];
            bool[][] isHonest = new bool[N][];
            var testimonyCount = new int[N];
            for (int i = 0; i < N; i++)
            {
                testimonyCount[i] = int.Parse(Console.ReadLine());
                target[i] = new int[testimonyCount[i]];
                isHonest[i] = new bool[testimonyCount[i]];
                for (int j = 0; j < testimonyCount[i]; j++)
                {
                    var testimony = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    target[i][j] = testimony[0];
                    isHonest[i][j] = (testimony[1] == 1);
                }
            }

            var result = 0;
            for (int hypothesis = (1 << N) - 1; hypothesis >= 0; hypothesis--)
            {
                var isHypothesisSatisfied = true;
                var honestCount = 0;
                for (int checkHonest = 0; checkHonest < N; checkHonest++)
                {
                    if (((1 << checkHonest) & hypothesis) > 0)
                    {
                        var isTestimonySatisfied = true;
                        for (int checkTestimony = 0; checkTestimony < testimonyCount[checkHonest]; checkTestimony++)
                        {
                            if ((((1 << (target[checkHonest][checkTestimony] - 1)) & hypothesis) > 0) != isHonest[checkHonest][checkTestimony])
                            {
                                isTestimonySatisfied = false;
                                break;
                            }
                        }
                        if (isTestimonySatisfied)
                        {
                            honestCount++;
                        }
                        else
                        {
                            isHypothesisSatisfied = false;
                            break;
                        }
                    }
                }
                if (isHypothesisSatisfied)
                {
                    result = Math.Max(result, honestCount);
                }
            }
            Console.WriteLine(result);
        }
    }
}
