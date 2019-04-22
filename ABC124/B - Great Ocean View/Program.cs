using System;
using System.Linq;

namespace B___Great_Ocean_View
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            var hills = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            int max = 0;
            int count = 0;

            foreach(int i in hills)
            {
                if(i >= max)
                {
                    count++;
                    max = i;
                }
            }

            Console.WriteLine(count);
        }
    }
}
