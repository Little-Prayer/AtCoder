static long power(long a, long b)
{
    if (b == 0) return 1;
    var result = a;
    for (int i = 1; i < b; i++)
    {
        result *= a;
    }
    return result;
}