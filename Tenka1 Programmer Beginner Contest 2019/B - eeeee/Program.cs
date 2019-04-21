using System;

namespace B___eeeee
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var K = int.Parse(Console.ReadLine());

            char check = S[K-1];
            string result = "";

            for (int i = 0 ; i < N ; i++)
            {
                if(S[i] == check)
                {
                    result += check;
                }else{
                    result += "*";
                }
            }

            Console.WriteLine(result);
        }
    }
}
