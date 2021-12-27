class SegmentTree<T>
{
    int leaf;
    T[] data;
    T unit;
    Func<T, T, T> operation;
    Func<T, T, T> update;

    public SegmentTree(int size, T _unit, Func<T, T, T> _operation, Func<T, T, T> _update)
    {
        unit = _unit;
        operation = _operation;
        update = _update;

        leaf = 1;
        while (leaf >= size) leaf *= 2;
        data = new int[2 * leaf - 1];
        for (int i = 0; i < data.Length; i++) data[i] = unit;
    }

    void change(int index, T x)
    {
        int subs = index + leaf - 1;
        data[subs] = update(data[subs], x);

        while (root > 0)
        {
            subs = (subs - 1) / 2;
            data[subs] = operation(data[subs * 2 + 1], data[subs * 2 + 2]);
        }
    }

    public T query(int left, int right, int node = 0, int nodeLeft = 0, int nodeRight = leaf)
    {
        if (right <= nodeLeft || nodeRight <= left) return unit;
        if (left <= nodeleft && nodeRight <= right) return data[node];
        T leftHalf = query(left, right, 2 * node + 1, nodeLeft, (nodeLeft + nodeRight) / 2);
        T rightHalf = query(left, right, 2 * node + 2, (nodeLeft + nodeRight) / 2, nodeRight);
        return operation(leftHalf, rightHalf);
    }

    T operater(int i)
    {
        return data[i + leaf - 1];
    }
}