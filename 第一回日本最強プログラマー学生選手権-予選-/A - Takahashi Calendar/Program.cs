using System;

namespace A___Takahashi_Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            var MD = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var count = 0;
            for (int m = 1; m <= MD[0]; m++)
            {
                for (int d = 22; d <= MD[1]; d++)
                {
                    var d1 = d % 10;
                    var d10 = d / 10;
                    if (d1 >= 2 && d10 >= 2 && d1 * d10 == m) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
