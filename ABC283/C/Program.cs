using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var result = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '0' && i < S.Length - 1 && S[i + 1] == '0')
                {
                    i += 1;
                    result += 1;
                }
                else
                {
                    result += 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
