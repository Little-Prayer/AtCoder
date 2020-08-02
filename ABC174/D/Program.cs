using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var C = Console.ReadLine();
            var countR = 0;
            foreach (char c in C)
            {
                if (c == 'R') countR++;
            }
            var subC = C.Substring(0, countR);
            var countR2 = 0;
            foreach (char c2 in subC)
            {
                if (c2 == 'R') countR2++;
            }
            Console.WriteLine(countR - countR2);
        }
    }
}
