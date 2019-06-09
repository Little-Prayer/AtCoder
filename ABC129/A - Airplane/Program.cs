using System;

namespace A___Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            var AB = read[0];
            var BC = read[1];
            var CA = read[2];

            Console.WriteLine(Math.Min(AB+BC,Math.Min(BC+CA,CA+AB)));
        }
    }
}
