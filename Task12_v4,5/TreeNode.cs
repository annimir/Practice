using System;
using System.Collections.Generic;
using System.Text;

namespace Task12_v4_5
{
    // Простая реализация бинарного дерева
    public class TreeNode
    {
        public TreeNode(int data)
        {
            Data = data;
        }

        // Данные
        public int Data { get; set; }

        // Левая ветка дерева
        public TreeNode Left { get; set; }

        // Правая ветка дерева
        public TreeNode Right { get; set; }

        // Рекурсивное добавление узла в дерево
        public void Insert(TreeNode node, ref int count_compare, ref int count_changed)
        {
            count_compare++;
            if (node.Data < Data)
            {            
                if (Left == null)
                {
                    Left = node;
                    count_changed++;
                }
                else
                {
                    Left.Insert(node, ref count_compare, ref count_changed);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                    count_changed++;
                }
                else
                {
                    Right.Insert(node, ref count_compare, ref count_changed);
                }
            }
        }

        // Преобразование дерева в отсортированный массив
        public int[] Transform(List<int> elements, ref int count_compare, ref int count_changed)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                count_changed++;
                Left.Transform(elements, ref count_compare, ref count_changed);
            }

            elements.Add(Data);

            if (Right != null)
            {
                count_changed++;
                Right.Transform(elements, ref count_compare, ref count_changed);

            }
            return elements.ToArray();
            
        }

        // Метод для сортировки с помощью двоичного дерева
        public static int[] TreeSort(int[] array, ref int count_compare, ref int count_changed)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]), ref count_compare, ref count_changed);
            }

            return treeNode.Transform(new List<int>(), ref count_compare, ref count_changed);
        }
    }
}
