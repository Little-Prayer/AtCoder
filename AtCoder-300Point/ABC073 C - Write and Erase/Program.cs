using System;

namespace ABC073_C___Write_and_Erase
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var numbers = new long[N];
            for (int i = 0; i < N; i++) numbers[i] = long.Parse(Console.ReadLine());

            Array.Sort(numbers);
            var count = N;
            for (int i = 1; i < N; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    numbers[i] = 0;
                    numbers[i - 1] = 0;
                    count -= 2;
                }
            }
            Console.WriteLine(count);
        }
    }
}
