using System;
using System.Linq;
using System.Collections.Generic;

namespace F
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        string solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var remain = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (remain.Sum() != (N - 1) * 2) return "-1";
            var groups = new Dictionary<int, Group>();
            var groupCount = 0;
            var groumnumber = new int[N + 1];


        }
    }
    class Group
    {
        int remainSum;
        List<int> members;

        Group()
        {
            members = new List<int>();
            remainSum = 0;
        }
    }

}
