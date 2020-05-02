using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine());
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = false;
            for (int i = AB[0]; i <= AB[1]; i++)
            {
                if ((i % K) == 0)
                {
                    result = true;
                    break;
                }
            }
            Console.WriteLine(result ? "OK" : "NG");
        }
    }
}
