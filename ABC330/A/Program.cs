var NL = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);
var N = NL[0];var L = NL[1];
var A = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);

Console.WriteLine(A.Where(point => point>=L).Count());