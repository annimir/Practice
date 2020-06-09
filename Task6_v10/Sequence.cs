using System;

namespace Task6_v10
{
    class Sequence
    {
        static void Function(int n, long[] MasDigit)
        {
            if (n > 3)
            {
                Function(n - 1, MasDigit);
            }

            MasDigit[n] = 13 * MasDigit[n - 1] - 10 * MasDigit[n - 2] + MasDigit[n - 3];
        }

        static void Main(string[] args)
        {
            int a1, a2, a3, n;
            a1 = 1;
            a2 = 2;
            a3 = 3;
            n = 20;

            if (n >= 4)
            {
                long[] MasDigit = new long[n];
                MasDigit[0] = a1;
                MasDigit[1] = a2;
                MasDigit[2] = a3;
                Function(n - 1, MasDigit);

                Console.WriteLine($"Полученная последовательность: {String.Join(" ", MasDigit)}");
            }
            else
            {
                Console.WriteLine("с данным n всё бессмысленно");
            }

            Console.ReadKey();
        }
    }
}
