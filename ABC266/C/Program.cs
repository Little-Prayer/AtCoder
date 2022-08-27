using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var D = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);


            double kakudo(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
            {
                (double x, double y) BA = (Ax - Bx, Ay - By);
                (double x, double y) BC = (Cx - Bx, Cy - By);
                var cosABC = (BA.x * BC.x + BA.y * BC.y) / (Math.Sqrt(BA.x * BA.x + BA.y * BA.y) * Math.Sqrt(BC.x * BC.x + BC.y * BC.y));
                return Math.Acos(cosABC) * 180 / Math.PI;
            }
            var ABC = kakudo(C[0], C[1], B[0], B[1], A[0], A[1]);
            if (ABC > 180) ABC -= 180;
            var BCD = kakudo(B[0], B[1], C[0], C[1], D[0], D[1]);
            if (BCD > 180) BCD -= 180;
            var CDA = kakudo(C[0], C[1], D[0], D[1], A[0], A[1]);
            if (CDA > 180) CDA -= 180;
            var DAB = kakudo(D[0], D[1], A[0], A[1], B[0], B[1]);
            if (DAB > 180) DAB -= 180;
            Console.WriteLine((int)(ABC + BCD + CDA + DAB) < 359 ? "No" : "Yes");
        }
    }
}
