using System;

namespace C___Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());
            var maxIndex = 1;
            var second = 0;
            for (int i = 1; i < N; i++)
            {
                var Ai = int.Parse(Console.ReadLine());
                if (second <= Ai)
                {
                    if (max <= Ai)
                    {
                        second = max;
                        max = Ai;
                        maxIndex = i + 1;
                    }
                    else
                    {
                        second = Ai;
                    }
                }
            }
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(i == maxIndex ? second : max);
            }
        }
    }
}
