using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    /*
     * Томашевич
     * 
     * 1. Реализовать простейшую хэш-функцию.
     * 2. Переписать программу, реализующее двоичное дерево поиска:
     *      Добавить в него обход дерева различными способами.
     *      Реализовать поиск в нём.
     *      
     */

    class Program
    {
        static void Main(string[] args)
        {
            // хэш-функция
            string str = "Just simlple string";
            Console.WriteLine($"1. Hash({str}) = {SimpleHash(str)}");

            int size = 20;
            Random rnd = new Random();

            int[] arr = new int[size];

            for (int i = 0; i < size; arr[i++] = rnd.Next(1, 101)) ;

            // создание дерева из массива данных arr
            Node tree = CreateTree(arr);

            // варианты обохода
            NLR(tree);
            Console.WriteLine();
            LNR(tree);
            Console.WriteLine();
            LRN(tree);

            // поиск
            Console.WriteLine("\n" + Search(tree, arr[10]).data);

            Console.ReadLine();
        }

        
        static long SimpleHash(string s)
        {
            int res = 0;

            for(int i = 0; i < s.Length-2; i++)
            {
                res += s[i] + s[i + 1] + s[i + 2];
            }
            return res;
        }

        class Node
        {
            public Node parent;
            public Node left;
            public Node right;
            public int data;

            public Node() { }
            public Node(int _data) { data = _data; }
        }

        /// <summary>
        /// Создает дерево и возвращает его корневой узел
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static Node CreateTree(int[] arr)
        {
            Node parent = new Node();
            parent.data = arr[0];

            for(int i = 1; i < arr.Length; i++)
            {
                SetDataToNode(parent, arr[i]);
            }

            return parent;
        }

        /// <summary>
        /// Добавляет данные в дерево, корень которого указан в качестве аргумента
        /// </summary>
        /// <param name="n">Корень дерева</param>
        /// <param name="d">Данные</param>
        static void SetDataToNode(Node n, int d)
        {
            if(d >= n.data)
            {
                if (n.right == null)
                {
                    n.right = new Node(d);
                }
                else SetDataToNode(n.right, d);
            }
            else
            {
                if (n.left == null)
                {
                    n.left = new Node(d);
                }
                else SetDataToNode(n.left, d);
            }
        }

        // cемейство функций обходов дерева
        static void NLR(Node n)
        {
            Console.WriteLine(n.data);
            if (n.left != null) NLR(n.left);
            if (n.right != null) NLR(n.right);
        }
        static void LNR(Node n)
        {
            if (n.left != null) NLR(n.left);
            Console.WriteLine(n.data);
            if (n.right != null) NLR(n.right);
        }
        static void LRN(Node n)
        {
            if (n.left != null) NLR(n.left);
            if (n.right != null) NLR(n.right);
            Console.WriteLine(n.data);
        }

        /// <summary>
        /// Реализует поиск в двоичном дереве tree (обход NLR)
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="what"></param>
        /// <returns></returns>
        static Node Search(Node tree, int what)
        {
            if (tree.data == what) return tree;
            else if (tree.data < what && tree.right != null) return Search(tree.right, what);
            else if (tree.data > what && tree.left != null) return Search(tree.left, what);
            else return null;
        }
    }
}
