using System;
using System.Linq;

namespace C___Five_Transportations
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var moveTimes = new long[5];

            moveTimes[0] = long.Parse(Console.ReadLine());
            moveTimes[1] = long.Parse(Console.ReadLine());
            moveTimes[2] = long.Parse(Console.ReadLine());
            moveTimes[3] = long.Parse(Console.ReadLine());
            moveTimes[4] = long.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((decimal)N/moveTimes.Min())+4);
        }
    }
}
