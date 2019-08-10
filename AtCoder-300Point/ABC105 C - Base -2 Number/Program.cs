using System;

namespace ABC105_C___Base__2_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var result = "";
            while (N != 0)
            {
                result = ((N % 2 == 0) ? "0" : "1") + result;
                N = (N >= 0) ? N / 2 * -1 : ((N * -1) + 1) / 2;
            }
            if (result == "") result = "0";
            Console.WriteLine(result);
        }
    }
}
