using System;

namespace C___Back_and_Forth
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var sx = read[0];
            var sy = read[1];
            var tx = read[2];
            var ty = read[3];

            int x = sx;
            int y = sy;

            string answer = "";

            for(; x < tx ; x++) answer += "R";
            for(; y < ty ; y++) answer += "U";
            for(; x > sx ; x--) answer += "L";
            for(; y > sy ; y--) answer += "D";
            answer += "D"; y--;
            for(; x < tx + 1 ; x++) answer += "R";
            for(; y < ty ; y++) answer += "U";
            answer += "L"; x--;
            answer += "U"; y++;
            for(;x > sx-1 ; x--) answer += "L";
            for(;y > sy ; y--) answer += "D";
            answer += "R"; x++;


            Console.WriteLine(answer);
        }
    }
}
