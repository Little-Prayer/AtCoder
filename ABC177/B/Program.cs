using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            var max = 0;
            for (int i = 0; i + T.Length <= S.Length; i++)
            {
                var current = 0;
                for (int j = 0; j < T.Length; j++)
                {
                    if (S[i + j] == T[j]) current++;
                }
                if (max < current) max = current;
            }
            Console.WriteLine(T.Length - max);
        }
    }
}
