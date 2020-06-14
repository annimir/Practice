using System;
using System.Collections.Generic;
using System.IO;

namespace Task11_v839
{
    class Crypter
    {
        static Random random = new Random();

        static StreamReader reader = new StreamReader("input.txt");  // Файл для чтения данных
        static StreamWriter writer = new StreamWriter("output.txt"); // Файл для записи данных

        // Ввод длины последовательности перестановки
        static int NumberInput()
        {
            int number;
            while(!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.WriteLine("Ошибка. Вы ввели неверно длину перестановки. Повторите ввод");
            }
            return number;
        }

        // Создание последовательности перестановок
        static List<int> Transposition(int k)
        {
            List<int> tmp = new List<int>();
            for(int i = 0; i < k; i++)
            {
                tmp.Add(i);
            }

            List<int> vector = new List<int>();
            for (int i = 0; i < k; i++)
            {
                vector.Add(0);
            }

            for (int i = 0; i < k; i++)
            {
                int pos = random.Next(0, tmp.Count);
                vector[i] = tmp[pos];

                tmp.Remove(tmp[pos]);
            }

            return vector;
        }

        static void PrintTransposition(List<int> transposition)
        {
            Console.WriteLine("Шифр");
            int pos = 1;
            for(int i = 0; i < transposition.Count; i++)
            {
                Console.Write($"{pos} -> {transposition[i]+1}; ");
                pos++;
            }
            Console.WriteLine();
        }

        // Зашифровка текста
        static string Encrypt(string text, int k, List<int> transposition)
        {
            string encrypt = "";

            for(int i = 0; i < text.Length; i += k)
            {
                string temp = "";
                for (int j = i; (j < i + k) && j < text.Length; j++)
                {
                    temp += text[j];
                }

                if (temp.Length < k)
                {
                    for(int j = temp.Length -1; j < k; j++)
                    {
                        temp += ' ';
                    }
                }

                char[] crypt = new char[k];

                for (int j = 0; j < k; j++)
                {
                    int pos = transposition.IndexOf(j);
                    crypt[j] = temp[pos];
                }
                string add = new string(crypt);
                encrypt += add;
            }

            return encrypt;
        }

        // Расшифровка текста
        static string Decrypt(string text, int k, List<int> transposition)
        {
            string decrypt = "";

            for (int i = 0; i < text.Length; i += k)
            {
                string temp = "";
                for (int j = i; j < i + k; j++)
                {
                    temp += text[j];
                }

                char[] crypt = new char[k];

                for (int j = 0; j < k; j++)
                {
                    crypt[j] = temp[transposition.IndexOf(j)];
                }

                string add = new string(crypt);
               

                if (i == text.Length - 1) add = String.Join(null, add.Split(' '));

                decrypt += add;
            }

            return decrypt;
        }

        static void Main(string[] args)
        {
            // Длина последовательности перестановки
            Console.WriteLine("Введите длину последовательности перестановки");
            int k = NumberInput();

            // Последовательность перестановок
            List<int> relocation = Transposition(k);

            // Текст который нужно засшифровать
            string text = reader.ReadToEnd();

            PrintTransposition(relocation);

            // Зашифрованный текст
            string crypt = Encrypt(text, k, relocation);

            Console.WriteLine("Текст был зашифрован и записан в файл");
            writer.WriteLine("Зашифрованный текст: ");
            writer.WriteLine(crypt);

            // Расшифрованный текст
            crypt = Decrypt(crypt, k, relocation);

            Console.WriteLine("Текст был расшифрован и записан в файл");
            writer.WriteLine("Расшифрованный текст: ");
            writer.WriteLine(crypt);

            writer.Close();
        }
    }
}
