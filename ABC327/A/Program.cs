var N = int.Parse(Console.ReadLine());
var S = Console.ReadLine();

Console.WriteLine((S.Contains("ab") || S.Contains("ba")) ? "Yes" : "No");