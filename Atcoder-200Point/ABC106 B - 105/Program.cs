using System;

namespace ABC106_B___105
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = 0;
            for (int target = 1; target <= n; target += 2)
            {
                var divisor = 0;
                for (int i = 1; i <= target; i++)
                    if ((target % i) == 0) divisor++;

                if (divisor == 8) result++;
            }
            Console.WriteLine(result);
        }
    }
}
