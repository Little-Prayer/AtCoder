using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var XYZ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XYZ[0]; var Y = XYZ[1]; var Z = XYZ[2];

            if (X > 0)
            {
                if (X < Y || Y < 0)
                {
                    Console.WriteLine(X);
                }
                else if (Z < Y && 0 < Z)
                {
                    Console.WriteLine(X);
                }
                else if (Y < Z)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(Math.Abs(Z) * 2 + X);
                }
            }
            else
            {
                if (Y < X || Y > 0)
                {
                    Console.WriteLine(Math.Abs(X));
                }
                else if (Y < Z && Z < 0)
                {
                    Console.WriteLine(Math.Abs(X));
                }
                else if (Y > Z)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(Math.Abs(X) + Math.Abs(Z) * 2);
                }
            }
        }
    }
}
