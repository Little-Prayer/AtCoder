long B = long.Parse(Console.ReadLine()!);

for (long i = 1; i > 0; i++)
{
    long current = i;
    for (long count = i; count > 1; count--)
    {
        current *= i;
    }
    if (B == current) { Console.WriteLine(i); break; }
    if (B < current) { Console.WriteLine(-1); break; }
}