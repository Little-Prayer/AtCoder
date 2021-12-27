static long modPow(long a, long n, long mod)
{
    long result = 1;
    while (n > 0)
    {
        if ((n & 1) > 0) result = result * a % mod;
        a = a * a % mod;
        n >>= 1;
    }
    return result;
}