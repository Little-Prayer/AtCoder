using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Convert.ToString(int.Parse(Console.ReadLine()), 16);
            if (s.Length == 1) s = "0" + s;
            Console.WriteLine(s.ToUpper());
        }
    }
}
