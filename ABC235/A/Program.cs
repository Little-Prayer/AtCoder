using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var abc = Console.ReadLine();
            var a = int.Parse(abc[0].ToString());
            var b = int.Parse(abc[1].ToString());
            var c = int.Parse(abc[2].ToString());
            Console.WriteLine((a + b + c) * 111);
        }
    }
}
