using System;

namespace _016___Minimum_Coins_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var ABC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = ABC[0]; var B = ABC[1]; var C = ABC[2];

            var result = int.MaxValue;

            for (int a = 0; a <= Math.Min(9999, N / A); a++)
            {
                for (int b = 0; b <= Math.Min(9999 - a, (N - a * A) / B); b++)
                {
                    if ((N - a * A - b * B) % C == 0)
                    {
                        var c = (N - a * A - b * B) / C;
                        result = Math.Min(result, a + b + c);
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
