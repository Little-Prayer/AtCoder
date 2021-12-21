using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            int temp = S[0] - T[0];
            if (temp < 0) temp += 26;
            var result = true;
            for (int i = 1; i < S.Length; i++)
            {
                var current = S[i] - T[i];
                if (current < 0) current += 26;
                if (temp != current)
                {
                    result = false;
                    break;
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
