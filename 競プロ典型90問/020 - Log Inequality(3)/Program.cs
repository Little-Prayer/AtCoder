using System;

namespace _020___Log_Inequality_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var abc = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var temporary = abc[2];
            for (int i = 1; i < abc[1]; i++) temporary *= abc[2];

            Console.WriteLine(abc[0] < temporary ? "Yes" : "No");
        }
    }
}
