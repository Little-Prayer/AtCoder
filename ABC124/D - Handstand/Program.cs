using System;
using System.Collections.Generic;
using System.Linq;

namespace D___Handstand
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var N = int.Parse(read[0]);
            var K = int.Parse(read[1]);

            var S = Console.ReadLine();

            var switch01 = new List<int>();
            switch01.Add(0);

            for(int i = 1 ; i < S.Length ; i++) if(S[i] != S[i-1]) switch01.Add(i);
            switch01.Add(S.Length);

            var continuousHandstand = new List<int>();
            
            for(int i = 0 ; i < switch01.Count-1 ; i++) continuousHandstand.Add(S[switch01[i]] == '0' ? switch01[Math.Min(switch01.Count-1,i+2*K)]-switch01[i] : switch01[Math.Min(switch01.Count-1,i+2*K+1)]-switch01[i]);
            
            Console.WriteLine(continuousHandstand.Max());
        }
    }
}
