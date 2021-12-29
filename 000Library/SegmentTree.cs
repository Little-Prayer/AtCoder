using System;
class SegTree
{
    int size;
    int[] tree, lazy;
    SegTree(int _size)
    {
        size = 1;
        while (size < _size) size << 1;
        tree = new int[2 * size + 1];
        lazy = new int[2 * size + 1];
    }
    void eval(int target)
    {
        if (lazy[target] == 0) return;
        if (target < size - 1)
        {
            lazy[target * 2 + 1] = Max(lazy[target * 2 + 1], lazy[target]);
            lazy[target * 2 + 2] = Max(lazy[target * 2 + 2], lazy[target]);
        }
        tree[target] = Max(tree[target], lazy[target]);
        lazy[target] = 0;
    }
    void update(int left, int right, int value, int current = 0, int rangeLeft = 0, int rangeRight = tree.Length)
    {
        eval(current);
        if (left <= rangeleft && rangeRight <= right) lazy[current] = value;
        else if (left < rangeRight || rangeLeft < right)
        {
            update(left, right, value, current * 2 + 1, rangeLeft, (rangeLeft + rangeright) / 2);
            update(left, right, value, current * 2 + 2, (rangeLeft + rangeRight) / 2, rangeRight);
            tree[current] = Math.Max(tree[current * 2 + 1], tree[current * 2 + 2]);
        }

    }
    int query(int left, int right, int current = 0, int rangeLeft = 0, int rangeRight = tree.Length)
    {
        eval(current);
        if (right <= rangeleft || rangeRight <= left) return 0;
        else if (rangeLeft <= left && right <= rangeright) return tree[current];
        else
        {
            var l = query(left, right, current * 2 + 1, rangeLeft, (rangeLeft + rangeRight) / 2);
            var r = query(left, right, current * 2 + 2, (rangeLeft + rangeRight) / 2, rangeRight);
            return Max(l, r);
        }
    }
}