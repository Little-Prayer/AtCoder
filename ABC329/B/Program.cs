var N = int.Parse(Console.ReadLine()!);
var A = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);

Console.WriteLine(A.Distinct().OrderByDescending(n=>n).Skip(1).Max());
