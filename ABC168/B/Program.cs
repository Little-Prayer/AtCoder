using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            if (S.Length <= K) Console.WriteLine(S);
            else Console.WriteLine(S.Substring(0, K) + "...");
        }
    }
}
