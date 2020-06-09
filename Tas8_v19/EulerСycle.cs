using System;
using System.Collections.Generic;

namespace Tas8_v19
{
    public class EulerСycle
    {
        // Матрица смежности
        static int[,] matrix = null;

        // Функция для проверки ввода размера матрицы смежности
        static int SizeInput()
        {
            int number;
            Console.WriteLine("Введите размер матрицы смежности");

            while(!(int.TryParse(Console.ReadLine(), out number)) || number < 0)
            {
                Console.WriteLine("Ошибка. Вы ввели неверный размер матрицы, повторите ввод.");
            }

            return number;
        }

        // Функция для корректного ввода элементов матрицы смежности
        static int ElemInput(int i, int j)
        {
            Console.WriteLine($"Введите {j} элемент {i} строки матрицы смежности");
            int number;
            while (!(int.TryParse(Console.ReadLine(), out number)) || number < 0 || number > 1)
            {
                Console.WriteLine("Ошибка. Вы ввели элемент матрицы, повторите ввод.");
            }

            return number;

        }

        // Функция для заполения матрицы смежности
        static int[,] MatrixInput(int size)
        {
            int[,] _matrix = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    _matrix[i, j] = ElemInput(i + 1, j + 1);
                }
            }

            return _matrix;
        }

        static void Main(string[] args)
        {
            int size = SizeInput();
            matrix = MatrixInput(size);

            List<int> deg = new List<int>(size);

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    deg[i] += matrix[i, j];
                }
            }

            int first = 0;
            while (deg[first] == 0) ++first;

            int v1 = -1; // Первая вершина нечетной степени
            int v2 = -1; // Вторая вершина нечетной степени

            bool linked = false; // Несвязный ли граф

            for (int i = 0; i < size; ++i)
            {
                if ((deg[i] & 1) == 0)
                {
                    if (v1 == -1)
                    {
                        v1 = i;
                    }
                    else
                    {
                        if (v2 == -1)
                            v2 = i;
                        else
                            linked = true;
                    }
                }
            }

            if(v1 != -1)
            {
                ++matrix[v1, v2]; 
                ++matrix[v2, v1];
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(first);

            List<int> res = new List<int>();

            while(stack.Count != 0)
            {
                int v = stack.Peek();
                int pos;

                for(pos = 0; pos < size; pos++)
                {
                    if (matrix[v, pos] != 0)
                    {
                        break;
                    }
                }

                if(pos == size)
                {
                    res.Add(v);
                    stack.Pop();
                }
                // Удаляем фиктивное ребро
                else
                {
                    --matrix[v, pos];
                    --matrix[pos, v];
                    stack.Push(pos);
                }
            }

            if(v1 != -1)
            {
                for (int i=0; i+1 < res.Count; i++)
                {
                    if(res[i] == v1 && res[i+1] == v2 || res[i] == v2 && res[i + 1] == v1)
                    {
                        List<int> res2 = new List<int>();
                        for(int j = i + 1; j < res.Count; j++)
                        {
                            res2.Add(res[j]);
                        }

                        for (int j = 1; j <= i; j++)
                        {
                            res2.Add(res[j]);
                        }

                        res = res2;
                        break;
                    }
                }
            }

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(matrix[i,j] != 0)
                    {
                        linked = true;
                    }
                }
            }

            // Если граф несвязный
            if (linked)
            {
                Console.WriteLine("Даннаый граф не соддержит эйлеров цикл");
            }
            else
            {
                Console.WriteLine("Данный граф соддержит эйлеров цикл");
                for(int i = 0; i < res.Count; i++)
                {
                    Console.Write($"{res[i] + 1} ");
                }
            }
        }
    }
}
