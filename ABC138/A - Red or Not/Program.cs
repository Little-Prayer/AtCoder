using System;

namespace A___Red_or_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            Console.WriteLine(a >= 3200 ? s : "red");
        }
    }
}
