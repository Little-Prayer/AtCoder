using System;
using System.Linq;

namespace ABC128E___Roadwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = read[0];
            var Q = read[1];

            var constructions = new Construction[N];
            for (int i = 0; i < N; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                constructions[i] = new Construction(read[0] - read[2], read[1] - read[2], read[2]);
            }

            var walker = new int[Q];
            for (int i = 0; i < Q; i++) walker[i] = int.Parse(Console.ReadLine());

            constructions = constructions.OrderBy(c => c.place).ToArray();

            var result = new int[Q];
            for (int i = 0; i < Q; i++) result[i] = -1;
            foreach (Construction c in constructions)
            {
                int index = lower_bound(walker, c.start);
                for (int i = index; walker[i] < c.end; i++) if (result[i] == -1) result[i] = c.place;
            }
            foreach (int i in result) Console.WriteLine(i);


        }
        static int lower_bound(int[] array, int value)
        {
            var low = 0;
            var high = array.Length - 1;

            while (low < high)
            {
                var mid = ((high - low) >> 1) + low;
                if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
    }
    struct Construction
    {
        public int start { get; }
        public int end { get; }
        public int place { get; }
        public Construction(int s, int e, int p)
        {
            this.start = s;
            this.end = e;
            this.place = p;
        }
    }
}
