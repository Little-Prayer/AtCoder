﻿using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(n > 3 || n == 1 ? "Yes" : "No");
        }
    }
}
