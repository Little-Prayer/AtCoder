using System;
using System.Collections.Generic;

IEnumerable<T[]> exhaustivelyEnumration<T>(params T[] arr) where T : IComparable<T>
{
    bool nextPermutation<S>(S[] arr, out S[] result) where S : IComparable<S>
    {
        int i;
        for (i = arr.Length - 2; i >= 0; i--)
            if (arr[i].CompareTo(arr[i + 1]) < 0)
                break;

        if (i < 0)
        {
            result = arr;
            return false;
        }
        int j;
        for (j = arr.Length - 1; j >= 0; j--)
            if (arr[i].CompareTo(arr[j]) < 0)
                break;

        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        Array.Reverse(arr, i + 1, arr.Length - i - 1);

        result = arr;
        return true;
    }
    Array.Sort(arr);
    yield return arr;
    while (nextPermutation(arr, out T[] result))
    {
        yield return result;
    }
    yield break;
}


