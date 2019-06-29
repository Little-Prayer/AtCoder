using System;

namespace B___Ordinary_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var pi = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = 0;
            for (int i = 1; i + 1 < N; i++) if ((pi[i] > pi[i + 1] && pi[i] < pi[i - 1]) || (pi[i] < pi[i + 1] && pi[i] > pi[i - 1])) result += 1;

            Console.WriteLine(result);
        }
    }
}
