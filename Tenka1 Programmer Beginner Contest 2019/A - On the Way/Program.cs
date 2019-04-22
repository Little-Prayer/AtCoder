using System;

namespace A___On_the_Way
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var A = int.Parse(read[0]);
            var B = int.Parse(read[1]);
            var C = int.Parse(read[2]);

            if((A <= C && C <= B)||(A >= C && C >= B)) 
            {
                Console.WriteLine("Yes");
            }else{
                Console.WriteLine("No");
            }
        }
    }
}
