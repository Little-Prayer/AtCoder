using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var subordinate = new int[N];
            foreach (int n in A) subordinate[n - 1]++;
            foreach (int n in subordinate) Console.WriteLine(n);
        }
    }
}
