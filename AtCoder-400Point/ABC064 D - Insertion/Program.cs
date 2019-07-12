using System;

namespace ABC064_D___Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var surplus = S.Substring(0);
            for (int i = 0; i < 50; i++) surplus = surplus.Replace("()", "");

            var countLeft = 0;
            var countRight = 0;
            for (int i = 0; i < surplus.Length; i++)
            {
                if (surplus[i] == '(') countLeft += 1;
                if (surplus[i] == ')') countRight += 1;
            }
            for (int i = 0; i < countRight; i++) S = "(" + S;
            for (int i = 0; i < countLeft; i++) S = S + ")";

            Console.WriteLine(S);
        }
    }
}
