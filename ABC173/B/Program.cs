using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var AC = 0; var WA = 0; var TLE = 0; var RE = 0;
            for (int i = 0; i < N; i++)
            {
                var result = Console.ReadLine();
                switch (result)
                {
                    case "AC":
                        AC++;
                        break;
                    case "WA":
                        WA++;
                        break;
                    case "TLE":
                        TLE++;
                        break;
                    case "RE":
                        RE++;
                        break;
                }
            }
            Console.WriteLine($"AC x {AC}");
            Console.WriteLine($"WA x {WA}");
            Console.WriteLine($"TLE x {TLE}");
            Console.WriteLine($"RE x {RE}");
        }
    }
}
