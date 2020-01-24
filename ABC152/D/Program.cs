using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var B = new int[10, 10];
            for (int i = 1; i < N + 1; i++)
            {
                var s = i.ToString();
                B[int.Parse(s[0].ToString()), int.Parse(s[s.Length - 1].ToString())] += 1;
            }

            var result = 0;
            for (int i = 1; i < N + 1; i++)
            {
                var s = i.ToString();
                result += B[int.Parse(s[s.Length - 1].ToString()), int.Parse(s[0].ToString())];
            }
            Console.WriteLine((result));
        }
    }
}
