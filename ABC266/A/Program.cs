﻿using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            Console.WriteLine(S[(S.Length + 1) / 2 - 1]);
        }
    }
}
