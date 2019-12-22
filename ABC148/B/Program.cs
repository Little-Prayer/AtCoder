using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var ST = Console.ReadLine().Split(' ');
            var S = ST[0]; var T = ST[1];
            for (int i = 0; i < N; i++)
            {
                Console.Write(S[i]);
                Console.Write(T[i]);
            }
        }
    }
}
