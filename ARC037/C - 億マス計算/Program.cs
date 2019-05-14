using System;

namespace C___億マス計算
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = read[0];
            var K = read[1];

            var rows = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var columns = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            Array.Sort(rows);
            Array.Sort(columns);

            var diagonal = 0;
            for(int i = 0 ; K < i ; i++) diagonal++;
        }
    }
}
