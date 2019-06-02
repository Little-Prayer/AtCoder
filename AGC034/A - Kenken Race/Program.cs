using System;

namespace A___Kenken_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var A = read[1];
            var B = read[2];
            var C = read[3];
            var D = read[4];
            var S = Console.ReadLine();

            var subS = S.Substring(A-1,Math.Max(C,D)-A+1);
            Console.WriteLine(solver(A-1,B-A,C-A,D-A,subS) ? "Yes":"No");            
        }
        static bool solver(int A,int B,int C,int D,string S)
        {
            if(S.IndexOf("##") >= 0) return false;
            if(C<D) return true;
            if(S.Substring(B,D-B+1).IndexOf("...")>=0) return true;
            if(S.Substring(D-1,3) == "...") return true;
            if(S.Substring(B-1,3) == "...") return true;
            return false;
        }
    }
}
