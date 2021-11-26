using System;

namespace _002___Encyclopedia_of_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < (1 << N); i++)
            {
                var target = Convert.ToString(i, 2).PadLeft(N, '0');
                if (parenthesesChecker(target))
                {
                    target = target.Replace('0', '(');
                    target = target.Replace('1', ')');
                    result.Append(target);
                    result.Append("\n");
                }
            }
            Console.WriteLine(result);
        }
        static bool parenthesesChecker(string target)
        {
            var count = 0;
            foreach (char a in target)
            {
                if (a == '0') count++;
                else count--;

                if (count < 0) return false;
            }
            return count == 0;
        }
    }
}
