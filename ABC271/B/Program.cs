using System;
using System.Collections.Generic;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var numbers = new List<List<int>>();
            numbers.Add(new List<int>());

            for (int i = 0; i < NQ[0]; i++)
            {
                var L = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var current = new List<int>();
                current.Add(0);
                for (int j = 1; j <= L[0]; j++) current.Add(L[j]);
                numbers.Add(current);
            }
            for (int i = 0; i < NQ[1]; i++)
            {
                var st = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(numbers[st[0]][st[1]]);
            }
        }
    }
}
