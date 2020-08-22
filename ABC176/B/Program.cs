using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            var sum = 0;
            for (int i = 0; i < N.Length; i++)
            {
                sum += int.Parse(N[i].ToString());
            }
            Console.WriteLine((sum % 9) == 0 ? "Yes" : "No");
        }
    }
}
