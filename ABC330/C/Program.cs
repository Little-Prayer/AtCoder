var D = long.Parse(Console.ReadLine()!);

var Square = new List<long>();
for (long i = 0; i * i <= D; i++) Square.Add(i * i);
Square.Add(Square.Count * Square.Count);

long result = long.MaxValue;
foreach (long x in Square)
{
    if (x > D) break;
    var current = Square.BinarySearch(D - x);
    if (current >= 0)
    {
        result = 0;
        break;
    }
    result = Math.Min(result, D - x - Square[~current - 1]);
    if (current * -1 < Square.Count) result = Math.Min(result, (D - x - Square[~current]) * -1);
}

Console.WriteLine(result);
