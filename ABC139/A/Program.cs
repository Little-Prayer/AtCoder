using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var yohou = Console.ReadLine();
            var jissai = Console.ReadLine();

            var count = 0;
            for (int i = 0; i < 3; i++) if (yohou[i] == jissai[i]) count++;
            Console.WriteLine(count);
        }
    }
}
