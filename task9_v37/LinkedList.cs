using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace task9_v37
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }

    public class LinkedList : IEnumerable  // односвязный список
    {
        private static Random random = new Random();

        Node head;  // головной/первый элемент
        Node tail;  // последний/хвостовой элемент
        int count;  // количество элементов в списке

        public int Count { get { return count; } }

        public bool IsEmpty { get { return count == 0; } }

        // добавление элемента
       public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        // удаление элемента
        public bool Remove(int data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // содержит ли список элемент
        public bool Contains(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // добвление в начало
        public void AppendFirst(int data)
        {
            Node node = new Node(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        // Печать связного списка
        public void PrintList()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Генерация связного списка с помощью ДСЧ
        public static LinkedList MakeList(int size)
        {
            LinkedList list = new LinkedList();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(-100, 100));
            }

            return list;
        }

        public static void MakePositiveAndNegativeList(ref LinkedList original, out LinkedList positive, out LinkedList negative)
        {
            positive = new LinkedList();
            negative = new LinkedList();

            foreach (var item in original)
            {
                if ((int)item > 0)
                {
                    positive.Add((int)item);
                    original.Remove((int)item);
                }
                if ((int)item < 0)
                {
                    negative.Add((int)item);
                    original.Remove((int)item);
                }
            }
        }       
    }
}
