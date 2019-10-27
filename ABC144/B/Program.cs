using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var result = false;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (i * j == N)
                    {
                        result = true;
                        break;
                    }
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
