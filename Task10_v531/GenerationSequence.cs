using System;

namespace Task10_v531
{
    class Program
    {
        static int SizeInput()
        {
            int number;
            Console.WriteLine("Введите количество элементов связного списка:");
            while (!(int.TryParse(Console.ReadLine(), out number)) || number < 2)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели количество элементов списка. Повторите ввод");
            }
            return number;
        }

        static void Main(string[] args)
        {
            int number = SizeInput();

            LinkedList original = LinkedList.MakeList(number);
            LinkedList linked = LinkedList.MakewNewList(original, number);

            Console.WriteLine("Список сгенерировался\nСписок:");
            original.PrintList();

            Console.WriteLine("Последовательность");
            linked.PrintList();
        }
    }
}
