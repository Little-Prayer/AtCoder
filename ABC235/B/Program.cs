using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var H = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = H[0];
            for (int i = 1; i < N; i++)
            {
                if (H[i] > H[i - 1])
                    result = H[i];
                else break;
            }
            Console.WriteLine(result);
        }
    }
}
