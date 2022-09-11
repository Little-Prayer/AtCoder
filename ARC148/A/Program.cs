using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var Amin = A.Min();
            A = A.Select(n => n - Amin).ToArray();

            var divisor = new List<int>();
            var Amax = A.Max();
            if (Amax == 0) return 1;
            if (Amax == 1) return 2;

            for (int i = 2; i < Math.Sqrt(Amax); i++)
            {
                if ((Amax % i) == 0)
                {
                    divisor.Add(i);
                    divisor.Add(Amax / i);
                }
            }
            if (divisor.Count() == 0) return 2;

            var result = true;
            foreach (int i in divisor)
            {
                result = true;
                foreach (int j in A)
                {
                    if ((j % i) > 0)
                    {
                        result = false;
                        break;
                    }

                }
                if (result)
                    break;
            }
            return result ? 1 : 2;
        }
    }
}
