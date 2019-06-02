using System;
using System.Text.RegularExpressions;

namespace B___ABC
{
    class Program
    {
        static int count;
        static Regex rx;
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            rx = new Regex("ABC");
            count = 0;
            var subS = S.Split(new string[]{"AC","BA","BB","CC"},StringSplitOptions.RemoveEmptyEntries);

            foreach(string str in subS)
            {
                replaceABC(str);
            }
            Console.WriteLine(count);
        }
        static string replaceABC(string S)
        {
            int _count = rx.Matches(S).Count;
            if(_count > 0)
            {
                count += _count;
                return replaceABC(S.Replace("ABC","BCA"));
            }else{
                return "0";
            }
        }
    }
}
