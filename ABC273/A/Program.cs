using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            int recur(int input)
            {
                if (input == 0) return 1;
                else return input * recur(input - 1);
            }
            Console.WriteLine(recur(N));
        }
    }
}
