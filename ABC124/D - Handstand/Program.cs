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

            for(int i = 1 ; i < S.Length-1 ; i++) if(S[i] != S[i-1]) switch01.Add(i);
            if(!switch01.Exists(n => n == S.Length-1)) switch01.Add(S.Length-1);

            var continuousHandstand = new List<int>();
            
            if(switch01.Count < 2*K) {
                continuousHandstand.Add(S.Length);
            }else{
                for(int start = S[0] == 0 ? 1 : 0;start + 2*K < switch01.Count ; start += 2) continuousHandstand.Add(switch01[start+2*K] - switch01[start]);
            }
            switch01.ForEach(s => Console.WriteLine(s));
            Console.WriteLine(continuousHandstand.Max());
        }
    }
}
