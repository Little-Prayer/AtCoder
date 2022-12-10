using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            int result;
            for (result = 0; result < S.Length; result++)
            {
                if (S[result] != T[result])
                {
                    break;
                }
            }
            Console.WriteLine(result + 1);
        }
    }
}
