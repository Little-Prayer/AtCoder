using System;

namespace ABC100_C___3_or_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var count = 0;
            for (int i = 0; i < ai.Length; i++)
            {
                var a = ai[i];
                while (a % 2 == 0)
                {
                    a /= 2;
                    count += 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}
