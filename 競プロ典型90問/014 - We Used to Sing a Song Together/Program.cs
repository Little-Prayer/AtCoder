using System;
using System.Linq;

namespace _014___We_Used_to_Sing_a_Song_Together
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(A.OrderBy(x => x).Zip(B.OrderBy(x => x), (x, y) => Math.Abs(x - y)).Sum());
        }
    }
}
