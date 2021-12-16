using System;

namespace _029___Long_Bricks_5_
{
    class Program
    {
        static void Main(string[] args)
        {
            var WN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var st = new SegmentTree(new int[WN[0]]);
            for (int i = 0; i < WN[1]; i++)
            {
                var lr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var current = st.query(lr[0] - 1, lr[1]);
                st.update(lr[0] - 1, lr[1], current + 1);
                Console.WriteLine(current + 1);
            }
        }

        struct SegmentTree
        {
            private int size;
            private int[] tree;
            private int[] lazy;

            public SegmentTree(int[] current)
            {
                size = 1;
                while (current.Length > size) size *= 2;
                tree = new int[size * 2 - 1];
                lazy = new int[size * 2 - 1];

                for (int i = 0; i < current.Length; i++) tree[i + size - 1] = current[i];
                for (int i = size - 2; i >= 0; i--) tree[i] = Math.Max(tree[2 * i + 1], tree[2 * i + 2]);
            }
            void eval(int target)
            {
                if (lazy[target] == 0) return;

                if (target < size - 1)
                {
                    lazy[target * 2 + 1] = lazy[target];
                    lazy[target * 2 + 2] = lazy[target];
                }
                tree[target] = lazy[target];
                lazy[target] = 0;
            }
            public int query(int left, int right, int current = 0, int l = 0, int r = -1)
            {
                if (r < 0) r = size;
                eval(current);
                if (r <= left || right <= l) return 0;
                else if (left <= l && r <= right) return tree[current];
                else
                {
                    return Math.Max(query(left, right, current * 2 + 1, l, (l + r) / 2), query(left, right, current * 2 + 2, (l + r) / 2, r));
                }
            }
            public void update(int left, int right, int up, int current = 0, int l = 0, int r = -1)
            {
                if (r < 0) r = size;
                eval(current);
                if (left <= l && r <= right)
                {
                    lazy[current] = up;
                    eval(current);
                }
                else if (left < r && l < right)
                {
                    update(left, right, up, current * 2 + 1, l, (l + r) / 2);
                    update(left, right, up, current * 2 + 2, (l + r) / 2, r);
                    tree[current] = Math.Max(tree[current * 2 + 1], tree[current * 2 + 2]);
                }
            }
        }
    }
}
