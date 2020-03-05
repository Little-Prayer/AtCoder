using System;

namespace ABC157_E___Simple_String_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var seg = new SegmentTree[26];
            for (int i = 0; i < 26; i++) seg[i] = new SegmentTree(N);
            for (int i = 0; i < N; i++)
            {
                seg[S[i] - 'a'].update(i, true);
            }

            var Q = int.Parse(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                var query = Console.ReadLine().Split(' ');
                if (query[0] == "1")
                {
                    var index = int.Parse(query[1]) - 1;
                    var alphabet = query[2][0] - 'a';
                    for (int j = 0; j < 26; j++)
                    {
                        seg[j].update(index, alphabet == j);
                    }
                }
                else
                {
                    var left = int.Parse(query[1]) - 1;
                    var right = int.Parse(query[2]);
                    int result = 0;
                    for (int j = 0; j < 26; j++)
                    {
                        if (seg[j].getValue(left, right)) result++;
                    }
                    Console.WriteLine(result);
                }
            }
        }
    }
    class SegmentTree
    {
        int size;
        bool[] node;

        public SegmentTree(int _size)
        {
            size = 1;
            while (size < _size) size *= 2;
            node = new bool[2 * size - 1];
        }
        public void update(int _index, bool value)
        {
            var index = _index + size - 1;
            node[index] = value;
            while (index > 0)
            {
                index = (index - 1) / 2;
                node[index] = node[index * 2 + 1] || node[index * 2 + 2];
            }
        }
        public bool getValue(int requestLeft, int requestRight, int currentIndex = 0, int currentLeft = 0, int currentRight = -1)
        {
            if (currentRight < 0) currentRight = size;

            if (requestLeft >= currentRight || requestRight <= currentLeft) return false;

            if (requestLeft <= currentLeft && currentRight <= requestRight) return node[currentIndex];

            bool childLeft = getValue(requestLeft, requestRight, 2 * currentIndex + 1, currentLeft, (currentLeft + currentRight) / 2);
            bool childRight = getValue(requestLeft, requestRight, 2 * currentIndex + 2, (currentLeft + currentRight) / 2, currentRight);
            return childLeft || childRight;
        }
    }
}
