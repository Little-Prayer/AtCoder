using system;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var mapA = new bool[N + 1, N + 1];
            var mapB = new bool[N + 1, N + 1];
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                mapA[ab[0], ab[1]] = true;
                mapA[ab[1], ab[0]] = true;
            }
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                mapB[ab[0], ab[1]] = true;
                mapB[ab[1], ab[0]] = true;
            }
            foreach (var item in GetPermutation<int>(Enumerable.Range(1, N))
        }
        public static IEnumerable<T[]> GetPermutation<T>(IEnumerable<T> collection)
        {
            // 未確定要素が一個のみ
            if (collection.Count() == 1)
            {
                yield return new T[] { collection.First() };
            }

            foreach (var item in collection)
            {
                var selected = new T[] { item };
                var unused = collection.Except(selected);

                // 確定した要素以外の組み合わせを再帰で取り出し連結
                foreach (var rightside in GetPermutation(unused))
                {
                    yield return selected.Concat(rightside).ToArray();
                }
            }
        }
    }
}
