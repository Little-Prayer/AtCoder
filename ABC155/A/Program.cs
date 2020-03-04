using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var ABC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (ABC[0] == ABC[1])
            {
                return ABC[0] != ABC[2];
            }
            else if (ABC[0] == ABC[2])
            {
                return true;
            }
            else
            {
                return ABC[1] == ABC[2];
            }
        }
    }
}
