using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < 5; i++)
            {
                if (x[i] == 0)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
