using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABCD = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var THP = ABCD[0]; var TAT = ABCD[1]; var AHP = ABCD[2]; var AAT = ABCD[3];
            var Tcount = (AHP + TAT - 1) / TAT;
            var Acount = (THP + AAT - 1) / AAT;
            Console.WriteLine(Tcount <= Acount ? "Yes" : "No");
        }
    }
}
