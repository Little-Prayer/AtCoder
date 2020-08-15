using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();

            var count = 0;
            var result = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'R') count++;
                else if (count > result)
                {
                    result = count;
                    count = 0;
                }
                else
                {
                    count = 0;
                }
            }
            if (count > result) result = count;
            Console.WriteLine(result);
        }
    }
}
