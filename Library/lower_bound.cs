using System;
static int lower_bound(int length, Func<int, bool> pred)
{
    int ng = -1;
    int ok = length;

    while (Math.Abs(ng - ok) > 1)
    {
        int mid = (ok + ng) / 2;

        if (pred(mid)) ok = mid;
        else ng = mid;
    }
    return ok;
}