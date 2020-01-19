using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = "";
            if (ab[0] > ab[1])
            {
                for (int i = 0; i < ab[0]; i++) result += ab[1].ToString();
            }
            else
            {
                for (int i = 0; i < ab[1]; i++) result += ab[0].ToString();
            }
            Console.WriteLine(result);
        }
    }
}
