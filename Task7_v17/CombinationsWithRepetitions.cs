using System;

namespace Task7_v17
{
    class CombinationsWithRepetitions
    {
        static int num = 1;
        static bool NextSet(int[] mas, int n, int m)
        {
            int j = m - 1;
            while (j >= 0 && mas[j] == n) j--;

            if (j < 0) return false;

            if (mas[j] >= n)
            {
                j--;
            }

            mas[j]++;
            if (j == m - 1) return true;

            for(int k = j + 1; k < m; k++)
            {
                mas[k] = mas[j];
            }

            return true;
        }

        static void Print(int[] mas, int n)
        {
            Console.Write($"{num++}: ");
            for(int i = 0; i < n; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }

        static int numberInput()
        {
            int number;
            while(!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Ошибка. Вы не верно ввели число. Повторите ввод");
            }

            return number;
        }

        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Введите N(колиечсто чисел множества):");
            n = numberInput();

            Console.WriteLine("Введите M(Количество чесел в наборе):");
            m = numberInput();

            int size = n > m ? n : m; // размер массива а выбирается как max(n,m)

            int[] mas = new int[size];

            for (int i = 0; i < size; i++)
                mas[i] = 1;

            //Print(mas, m);

            while (NextSet(mas, n, m))
                Print(mas, m);
        }
    }
}
