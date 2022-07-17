using System;
using System.Linq;
using System.Collections.Generic;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NXYZ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NXYZ[0]; var X = NXYZ[1]; var Y = NXYZ[2]; var Z = NXYZ[3];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var students = new List<(int number, int math, int english)>();
            for (int i = 0; i < N; i++) students.Add((i, A[i], B[i]));
            var passing = new List<int>();
            var first = students.OrderByDescending(s => s.math).ThenBy(s => s.number).Take(X);
            foreach (var s in first) passing.Add(s.number);
            var second = students.Where(s => !passing.Contains(s.number)).OrderByDescending(s => s.english).ThenBy(s => s.number).Take(Y);
            foreach (var s in second) passing.Add(s.number);
            var third = students.Where(s => !passing.Contains(s.number)).OrderByDescending(s => s.english + s.math).ThenBy(s => s.number).Take(Z);
            foreach (var s in third) passing.Add(s.number);

            foreach (var index in passing.OrderBy(s => s)) Console.WriteLine(index + 1);
        }
    }
}
