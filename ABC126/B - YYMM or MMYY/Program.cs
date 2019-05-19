using System;

namespace B___YYMM_or_MMYY
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var a = int.Parse(S.Substring(0,2));
            var b = int.Parse(S.Substring(2,2));

            if(isMonth(a) && isMonth(b)) Console.WriteLine("AMBIGUOUS");
            if(isMonth(a) && !isMonth(b)) Console.WriteLine("MMYY");
            if(!isMonth(a) && isMonth(b)) Console.WriteLine("YYMM");
            if(!isMonth(a) && !isMonth(b)) Console.WriteLine("NA");
        }
    static bool isMonth(int n)
    {
        return(n <=12 && n >= 1);
    }
    }

}
