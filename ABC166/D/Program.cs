using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = long.Parse(Console.ReadLine());
            long A, B;
            var isEnd = false;
            for (A = 1; A <= 500; A++)
            {
                for (B = -500; B <= 500; B++)
                {
                    if (A * A * A * A * A - B * B * B * B * B == X)
                    {
                        Console.WriteLine($"{A} {B}");
                        isEnd = true;
                        break;
                    }
                }
                if (isEnd) break;
            }
        }
    }
}
