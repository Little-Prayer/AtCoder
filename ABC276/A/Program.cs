using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var result = S.LastIndexOf("a");
            if (result >= 0) result++;
            Console.WriteLine(result);
        }
    }
}
