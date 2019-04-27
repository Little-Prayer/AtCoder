using System;
using System.Linq;

namespace B___Resale
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine();
            var N = int.Parse(read);

            var values = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var costs = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            int benefit = 0;

            for(int i = 0 ; i < N ; i++)
            {
                if(values[i] > costs[i])
                {
                    benefit += values[i] - costs[i];
                }
            }
            Console.WriteLine(benefit);
        }
    }
}
