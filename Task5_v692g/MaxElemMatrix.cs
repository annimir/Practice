using System;

namespace Task5_v692g
{
    class MaxElemMatrix
    {
        static int sizeInput()
        {
            int number;
            Console.WriteLine("Введите размер матрицы");
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели размер матрицы. Повторите ввод");
            }
            return number;
        }

        static int[,] matrixGeneration(int size) 
        {
            int[,] matrix = new int[size,size];
            Random random = new Random();

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(-100, 100);
                }
            }
          
            return matrix;
        }
        
        static void matrixPrint(int[,] matrix)
        {
            Console.WriteLine("Матрица:");
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] >= 0)
                    {
                        Console.Write(" {0}\t", matrix[i, j]);
                    }
                    else
                    {
                        Console.Write("{0}\t", matrix[i, j]);
                    }
                }
                Console.WriteLine();          
            }
        }

        static int maxElemMatrix(int[,] matrix)
        {
            int max = matrix[matrix.GetLength(0)-1,0];
            int postart = 0;
            for(int i=matrix.GetLength(0)-1; i >= matrix.GetLength(0) / 2; i--)
            {
                for(int j = postart; j < matrix.GetLength(1) - postart; j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                postart++;
            }
            return max;
        }
        static void Main(string[] args)
        {
            int size = sizeInput();
            int[,] matrix = matrixGeneration(size);
            Console.WriteLine("Матрица сгенерировна");
            matrixPrint(matrix);
            Console.WriteLine("Максимальное значение в нижнем треугольнике матрицы = " + maxElemMatrix(matrix));

        }
    }
}
