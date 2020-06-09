using System;

namespace Task3_v59z
{
    class DotAccessory
    {
        static bool Check(double x, double y)
        {
            if (x >= -1 && x <= 0 && y <= 3 * x + 2 || x >= 0 && x <= 1 && y <= -3 * x + 2)
                return true;
            return false;
        }

        static double numberInput()
        {
            double number;
            while(!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка. Вы не верно ввели координату. Повторите ввод");
            }
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввелите координату X:");
            double x = numberInput();

            Console.WriteLine("Ввелите координату Y:");
            double y = numberInput();

            if (Check(x, y))
            {
                Console.WriteLine($"Точка A({x};{y}) принедлежит закрашенной области");
            }
            else
            {
                Console.WriteLine($"Точка A({x};{y}) не принедлежит закрашенной области");
            }
        }
    }
}
