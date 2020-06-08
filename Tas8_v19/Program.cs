using System;

namespace Tas8_v19
{
    public class Program
    {
        static int SizeInput()
        {
            int number;
            Console.WriteLine("Введите размер матрицы смежности");

            while(!(int.TryParse(Console.ReadLine(), out number)) || number < 0)
            {

            }

            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
