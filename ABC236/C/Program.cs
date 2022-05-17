using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var stations = Console.ReadLine().Split(' ');
            var stops = Console.ReadLine().Split(' ');

            var check = new Dictionary<string, bool>();
            foreach (var station in stations) check.Add(station, false);
            foreach (var stop in stops) check[stop] = true;
            foreach (var station in stations) Console.WriteLine(check[station] ? "Yes" : "No");
        }
    }
}
