using System;

namespace task9_v37
{
    class GenerationLinkedLists
    {
        static int SizeInput()
        {
            int number;
            Console.WriteLine("Введите количество элементов связного списка:");
            while(!(int.TryParse(Console.ReadLine(), out number)) || number < 0)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели количество элементов списка. Повторите ввод");
            }
            return number;
        }
        static void Main(string[] args)
        {
            LinkedList original = new LinkedList();
            LinkedList positive;
            LinkedList negative;

            int size = SizeInput();

            original = LinkedList.MakeList(size);
            Console.WriteLine("Список сгенерировался\nСписок:");
            original.PrintList();

            LinkedList.MakePositivaandNegativeList(ref original, out positive, out negative);
            Console.WriteLine("Оригальный список после выполнения процедуры, создающей два новых линейных списка");
            original.PrintList();

            Console.WriteLine("Список с положительными числами:");
            positive.PrintList();

            Console.WriteLine("Список с отрицательными числами:");
            negative.PrintList();

        }
    }
}
