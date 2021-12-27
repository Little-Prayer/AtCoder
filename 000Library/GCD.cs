static long GCD(long A, long B)
{
    if (B > A) return GCD(B, A);
    if (A % B == 0)
    {
        return B;
    }
    else
    {
        return GCD(B, A % B);
    }
}