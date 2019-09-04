using System;

namespace AtCoder_Petrozavdsk_Contest_001_C___Vacant_Seat
{
    class Program
    {
        static void Main(string[] args)
        {
            solver();
        }

        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            var genders = new bool[N];
            Console.WriteLine(0);
            var read0 = Console.ReadLine();
            if (read0 == "Vacant") return 0;
            else genders[0] = read0 == "Male";

            var left = 0;
            var right = N;
            while (true)
            {
                var mid = (left + right) / 2;
                Console.WriteLine(mid);
                var read = Console.ReadLine();
                if (read == "Vacant") return 0;
                else genders[mid] = read == "Male";

                if ((mid % 2 == 0) == (genders[mid] == genders[0]))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
    }
}
