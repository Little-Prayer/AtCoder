using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var result = new int[N];

            for (int x = 1; x <= 100; x++)
            {
                for (int y = 1; y <= 100; y++)
                {
                    for (int z = 1; z <= 100; z++)
                    {
                        var fn = x * x + y * y + z * z + x * y + y * z + x * z;
                        if (fn <= N) result[fn - 1]++;
                    }
                }
            }
            foreach (int re in result) Console.WriteLine(re);
        }
    }
}
