using System;
static long lower_bound(long ng, long ok, Func<long, bool> pred)
{
    while (Math.Abs(ng - ok) > 1)
    {
        long mid = (ok + ng) / 2;

        if (pred(mid)) ok = mid;
        else ng = mid;
    }
    return ok;
}