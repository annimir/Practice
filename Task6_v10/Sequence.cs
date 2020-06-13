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

        static bool Parity(long[] masDigit)
        {
            for (int i = 3; i < masDigit.Length; i += 2)
            {
                if (masDigit[i-2] > masDigit[i])
                {
                    return false;
                }
            }

            return true;
        }

        static int NumberInput()
        {
            int number;
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка. Вы ввели не целое число, повторите ввод");
            }
            return number;
        }

        static int SizeInput()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 4)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели размер последовательности, повторите ввод");
            }
            return number;
        }

        static bool Check(int a1, int a2, int a3)
        {
            if (a1 == 0 && a2 == 0 && a3 == 0)
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ведите первый член последовательности");
            int a1 = NumberInput();
            Console.WriteLine("Ведите второй член последовательности");
            int a2 = NumberInput();
            Console.WriteLine("Ведите член член последовательности");
            int a3 = NumberInput();
            Console.WriteLine("Ведите размер последовательности больше 3");
            int n = SizeInput();

            if (Check(a1, a2, a3))
            {

                long[] MasDigit = new long[n];
                MasDigit[0] = a1;
                MasDigit[1] = a2;
                MasDigit[2] = a3;
                Function(n - 1, MasDigit);

                Console.WriteLine($"Полученная последовательность: {String.Join(" ", MasDigit)}");
                Console.WriteLine(Parity(MasDigit) ?
                    "Элементы, стоящие на четных местах, образуют возрастающую последовательность" :
                    "Элементы, стоящие на четных местах, не образуют возрастающую последовательность");

            }
            else
            {
                Console.WriteLine($"Каждый член последовательности равен 0");
            }
            Console.ReadKey();
        }
    }
}
