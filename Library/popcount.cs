static int popcount(long X)
{
    int result = 0;
    while (X > 0)
    {
        if ((X % 2) == 1) result++;
        X /= 2;
    }
    return result;
}