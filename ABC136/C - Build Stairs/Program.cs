using System;

namespace C___Build_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var Hi = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            for (int i = N - 1; i > 0; i--) if (Hi[i - 1] > Hi[i]) Hi[i - 1]--;
            for (int i = 0; i < N - 1; i++) if (Hi[i + 1] < Hi[i]) return false;
            return true;
        }
    }
}
