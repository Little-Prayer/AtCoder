using System;

namespace A___Changing_a_Character
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var K = read[1];
            string S = Console.ReadLine();
            String result = "";
            for(int i = 0 ; i < N ; i++)
            {
                if(i == K-1)
                {
                    result += S[i].ToString().ToLower();
                }else{
                    result += S[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}
