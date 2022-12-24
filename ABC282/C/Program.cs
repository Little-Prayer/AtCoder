using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var isWrapped = false;
            var result = new System.Text.StringBuilder();
            foreach (char c in S)
            {
                if (c == '\"')
                {
                    isWrapped = !isWrapped;
                    result.Append(c);
                }
                else if (c == ',' && !isWrapped)
                {
                    result.Append('.');
                }
                else
                {
                    result.Append(c);
                }
            }

            Console.WriteLine(result);
        }
    }
}
