using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(NM[0] == NM[1] ? "Yes" : "No");
        }
    }
}
