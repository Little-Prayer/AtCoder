using System;

namespace A___Dividing_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var K = 1;
            var previous = S[0].ToString();
            var now = "";
            for (int i = 1; i < S.Length; i++)
            {
                now += S[i];
                if (now != previous)
                {
                    K += 1;
                    previous = now;
                    now = "";
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(K);
        }
    }
}
