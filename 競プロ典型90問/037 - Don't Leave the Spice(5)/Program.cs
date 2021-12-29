using System;
using static System.Math;

namespace _037___Don_t_Leave_the_Spice_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var WN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var W = WN[0]; var N = WN[1];
            var spices = new int[N][];
            for (int i = 0; i < N; i++)
                spices[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var st = new SegTree(W);
            st.update(0, 1, 0);
            for (int i = 0; i < N; i++)
                for (int j = W - spices[i][0]; j >= 0; j--)
                    if (st.query(j) >= 0) st.update(j + spices[i][0], j + spices[i][1] + 1, st.query(j) + spices[i][2]);

            Console.WriteLine(st.query(W));
        }
        class SegTree
        {
            public int size;
            long[] tree, lazy;
            public SegTree(int _size)
            {
                size = 1;
                while (size < _size) size <<= 1;
                tree = new long[2 * size + 1];
                lazy = new long[2 * size + 1];
                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = -1;
                    lazy[i] = -1;
                }
            }
            void eval(int target)
            {
                if (lazy[target] == -1) return;
                if (target < size - 1)
                {
                    lazy[target * 2 + 1] = Max(lazy[target * 2 + 1], lazy[target]);
                    lazy[target * 2 + 2] = Max(lazy[target * 2 + 2], lazy[target]);
                }
                tree[target] = Max(tree[target], lazy[target]);
                lazy[target] = 0;
            }
            public void update(int left, int right, long value, int current = 0, int rangeLeft = 0, int rangeRight = -1)
            {
                if (rangeRight < 0) rangeRight = size;
                right = Math.Min(right, size);
                eval(current);

                if (left <= rangeLeft && rangeRight <= right)
                    lazy[current] = value;
                else if (left < rangeRight && rangeLeft < right)
                {
                    update(left, right, value, current * 2 + 1, rangeLeft, (rangeLeft + rangeRight) / 2);
                    update(left, right, value, current * 2 + 2, (rangeLeft + rangeRight) / 2, rangeRight);
                    tree[current] = Math.Max(tree[current * 2 + 1], tree[current * 2 + 2]);
                }

            }

            public long query(int target)
            {
                return query_sub(target + size - 1);
            }
            long query_sub(int target)
            {
                if (target > 0) query_sub((target - 1) / 2);
                eval(target);
                return tree[target];
            }
        }
    }
}
