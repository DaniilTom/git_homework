using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    class Program
    {
        /*
         * Томашевич 
         * 
         * 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной
         *      и неоптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
         * 2. *Реализовать шейкерную сортировку.
         * 3. Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив.
         *      Функция возвращает индекс найденного элемента или –1, если элемент не найден.
         *      4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
         */


        static void Main(string[] args)
        {
            int size = 50;

            int[] arr = new int[size];
            int[] arr1 = new int[size];
            int[] arr2 = new int[size];

            Random rnd = new Random();

            for (int i = 0; i < arr.Length; arr[i++] = rnd.Next(0, 10000)) ;

            Array.Copy(arr, arr1, arr.Length);
            Array.Copy(arr, arr2, arr.Length);

            Console.WriteLine("Обычная пузырьковая: " + BubleSort(arr) + " op.");
            Console.WriteLine("Улучшенная пузырьковая: " + BubleSortOptim(arr1) + " op.");
            Console.WriteLine("Шейкерная: " + ShakeSort(arr2) + " op.");
            Console.WriteLine("Двоичный поиск: индекс искомого элемента: " + BinarySearch(arr2, arr2[12]));

            /*
             * 
             * Сложность в худшем случае для всех сортировок O(n^2). Исключение множителей и членов более низкого порядка
             * делает данные сортировки одинаковыми. Однако, на практике улучшенная пузырьковая и шейкерная сортировки
             * в два раза быстрее, т.е. O((n^2)/2).
             * 
             * */

            Console.ReadLine();
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Обычная пузырьковая
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int BubleSort(int[] arr)
        {
            int count = 1;

            for(int i = 0; i < arr.Length - 1; i++, count++)
            {
                for (int j = 0; j < arr.Length - 1; j++, count++)
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        //count++;
                    }
            }

            return count;
        }

        /// <summary>
        /// Улучшенная пузырьковая
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int BubleSortOptim(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++, count++)
            {
                for (int j = 0; j < arr.Length - i -1; j++, count++)
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        //count++;
                    }
            }

            return count;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int ShakeSort(int[] arr)
        {
            int count = 0;

            int left = 0;
            int right = arr.Length - 1;

            while(left < right)
            {
                for(int i = left; i < right; i++, count++)
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        //count++;
                    }
                right--;

                for(int j = right; j > left; j--, count++)
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        //count++;
                    }
                left++;
            }

            /*for (int i = 0; i < arr.Length/2; i++, count++)
            {
                int j = i;

                for ( ; j < arr.Length - i - 1; j++, count++)
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        //count++;
                    }
                
                for( ; j > i ; j--, count++)
                    if(arr[j-1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        //count++;
                    }
            }*/

            return count;
        }


        /// <summary>
        /// Двоичный поиск
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static int BinarySearch(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            int index = 0;

            while(left != right)
            {
                index = (right + left) / 2;
                if (arr[index] == key) return index;
                else if (arr[index] > key) right = index;
                        else left = index;
            }

            return -1;
        }
    }
}
