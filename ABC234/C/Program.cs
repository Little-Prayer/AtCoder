using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = long.Parse(Console.ReadLine());
            var S = Convert.ToString(K, 2);
            Console.WriteLine(S.Replace('1', '2'));
        }
    }
}
