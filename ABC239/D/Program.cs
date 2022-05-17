using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime(int x)
            {
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if ((x % i) == 0) return false;
                }
                return true;
            }
            var ABCD = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = ABCD[0]; var B = ABCD[1]; var C = ABCD[2]; var D = ABCD[3];

            var winTakahashi = true;
            for (int Takahashi = A; Takahashi <= B; Takahashi++)
            {
                winTakahashi = true;
                for (int Aoki = C; Aoki <= D; Aoki++)
                {
                    if (isPrime(Takahashi + Aoki))
                    {
                        winTakahashi = false;
                        break;
                    }
                }
                if (winTakahashi) break;
            }
            Console.WriteLine(winTakahashi ? "Takahashi" : "Aoki");
        }
    }
}
