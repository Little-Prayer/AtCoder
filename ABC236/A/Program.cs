using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = "";
            for (int i = 0; i < S.Length; i++)
            {
                if (i == ab[0] - 1) result += S[ab[1] - 1];
                else if (i == ab[1] - 1) result += S[ab[0] - 1];
                else result += S[i];
            }
            Console.WriteLine(result);
        }
    }
}
