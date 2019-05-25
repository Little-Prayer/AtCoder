using System;

namespace A___Ferris_Wheel
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var A = read[0];
            var B = read[1];

            int result;

            if(A < 6){
                result = 0;
            }else if (A <= 12){
                result = B/2;
            }else{
                result = B;
            }

            Console.WriteLine(result);
        }
    }
}
