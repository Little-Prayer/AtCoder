using System;

namespace ABC122_B___ATCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var result = 0;
            for (int start = 0; start < S.Length; start++)
            {
                var count = 0;
                for (int end = start; end < S.Length; end++)
                {
                    if (S[end] == 'A' || S[end] == 'C' || S[end] == 'G' || S[end] == 'T')
                        count++;
                    else break;
                }
                if (count > result) result = count;
            }
            Console.WriteLine(result);
        }
    }
}
