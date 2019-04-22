using System;

namespace A___Buttons
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var A = int.Parse(read[0]);
            var B = int.Parse(read[1]);

            if(A==B)
            {
                Console.WriteLine(A*2);
            }else{
                var large = Math.Max(A,B);
                Console.WriteLine(large+(large-1));
            }
                
        }
    }
}
