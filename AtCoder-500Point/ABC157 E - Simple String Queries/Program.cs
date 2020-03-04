using System;

namespace ABC157_E___Simple_String_Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
            if (currentRight < 0) currentRight = size - 1;

            if (requestLeft >= currentRight || requestRight <= currentLeft) return false;

            if (requestLeft <= currentLeft && currentRight <= requestRight) return node[currentIndex];

            bool childLeft = getValue(requestLeft, requestRight, 2 * currentIndex + 1, currentLeft, (currentLeft + currentRight) / 2);
            bool childRight = getValue(requestLeft, requestRight, 2 * currentIndex + 2, (currentLeft + currentRight) / 2 + 1, currentRight);
            return childLeft || childRight;
        }
    }
}
