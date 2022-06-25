using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];
            var str = "";
            for (int i = 0; i < 26; i++)
                for (int j = 0; j < N; j++)
                {
                    char c = (char)('A' + i);
                    str += c;
                }
            Console.WriteLine(str[X - 1]);
        }
    }
}
