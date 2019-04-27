using System;

namespace ABC125
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var A = int.Parse(read[0]);
            var B = int.Parse(read[1]);
            var T = int.Parse(read[2]);
            long biscuits = 0;

            for(int i = A ; i <= T ; i += A)
            {
                biscuits += B;
            }
        Console.WriteLine(biscuits);
        }
    }
}
