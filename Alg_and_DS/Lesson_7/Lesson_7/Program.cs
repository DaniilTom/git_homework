using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    /*
     * Томашевич
     * 
     * 1. Написать рекурсивную функцию обхода графа в глубину.
     * 2. Написать функцию обхода графа в глубину.
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            // матрица смежности графа
            int[,] graph = new int[8, 8] {
                { 0, 1, 1, 1, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 0, 1, 0, 1 },
                { 1, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 1, 1 },
                { 0, 1, 0, 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 1, 1, 0, 1 },
                { 0, 1, 1, 0, 1, 1, 1, 0 }
                };

            // массив цветов: 0 - не обнаружен, 1 - обнаружен, 2 - обработан 
            int[] color = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            Console.WriteLine("Обход в ширину:");
            BFS(graph, 5, color);

            Console.WriteLine("\nОбход в глубину:");
            color = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; // обнудение цветов
            DFS(graph, 5, color);

            Console.ReadLine();
        }

        static QueueWithList queue = new QueueWithList();

        /// <summary>
        /// В глубину
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="color"></param>
        static void DFS(int[,] graph, int start, int[] color)
        {
            Console.WriteLine("node : " + start);
            color[start] = 1;

            for (int i = 0; i < 8; i++)
            {
                if (graph[start, i] == 1 && color[i] == 0)
                {
                    
                    DFS(graph, i, color);
                }
            }
        }

        /// <summary>
        /// В ширину
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="color"></param>
        static void BFS(int[,] graph, int start, int[] color)
        {
            queue.Enqueue(start);

            while(queue.Length != 0)
            {
                start = queue.Dequeue();
                Console.WriteLine("node : " + start);
                color[start] = 2;

                for (int i = 0; i < 8; i++)
                {
                    if (graph[start, i] == 1 && color[i] == 0)
                    {
                        color[i] = 1;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
