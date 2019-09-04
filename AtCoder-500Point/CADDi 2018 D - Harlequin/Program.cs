using System;

namespace CADDi_2018_D___Harlequin
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isSecond = true;
            for (int i = 0; i < N; i++) if (int.Parse(Console.ReadLine()) % 2 == 1) isSecond = false;
            Console.WriteLine(isSecond ? "second" : "first");
        }
    }
}
