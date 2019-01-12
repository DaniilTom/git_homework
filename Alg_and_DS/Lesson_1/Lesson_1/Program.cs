using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        /*
         * Томашевич
         * 
         * 10. Дано целое число N (> 0). С помощью операций деления нацело и взятия остатка от деления определить, имеются
         *      ли в записи числа N нечетные цифры. Если имеются, то вывести True, если нет — вывести False.
         * 11. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать среднее арифметическое всех 
         *      положительных четных чисел, оканчивающихся на 8.
         * 12. Написать функцию нахождения максимального из трех чисел. 
         * 13. * Написать функцию, генерирующую случайное число от 1 до 100: 
         *      с использованием стандартной функции rand()
         *      без использования стандартной функции rand()
         * 14. * Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.
         *      Например, 25 \ :sup:`2` = 625. Напишите программу, которая вводит натуральное число N и 
         *      выводит на экран все автоморфные числа, не превосходящие N
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Нечетные цифры есть? " + Task10());

            //Console.WriteLine("Average = " + Task11());

            //Console.WriteLine("Наибольшее из трех: " + Task12(40, 20, 30).ToString());

            //Console.WriteLine("Случайное число с rand: " + Task13_with_rand().ToString());

            //Console.WriteLine("Случайное число без rand: " + Task13_without_rand().ToString());
            //for (int i = 0; i < 100; i++) /*** можно посмотреть на генерируемую последовательность *****/
            //{
            //    Console.WriteLine("Случайное число без rand: " + Task12_without_rand().ToString());
            //}


            //Console.WriteLine("Автоморфные числа: ");
            //ulong s = unchecked((ulong)100000);
            //foreach(long l in Task14(s))
            //{
            //    Console.WriteLine(l.ToString());
            //}

            Console.ReadLine();
        }

        /// <summary>
        /// Определение наличия нечетных цифр
        /// </summary>
        /// <returns></returns>
        static bool Task10()
        {
            Console.WriteLine("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            while(a > 0)
            {
                if ((a % 10) % 2 != 0) return true;
                else a /= 10;
            }
            return false;
        }

        /// <summary>
        /// Подсчет среднего
        /// </summary>
        /// <returns></returns>
        static double Task11()
        {
            Console.WriteLine("Вводите числа (0 - закончить ввод): ");
            int count = -1;
            int number = 0;
            double sum = 0;
            do
            {
                sum += number;
                count++;
                number = Int32.Parse(Console.ReadLine());
            } while (number != 0);

            return sum / count;
        }

        /// <summary>
        /// Максимум из трех
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Task12(int a, int b, int c)
        {
            return (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
        }

        /// <summary>
        /// Рандом с class Random
        /// </summary>
        /// <returns></returns>
        static int Task13_with_rand()
        {
            return (new Random()).Next(1, 101);
        }

        /// <summary>
        /// Рандом без class Random();
        /// </summary>
        /// <returns></returns>
        static int Task13_without_rand()
        {
            // какая-никакая случайность
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            // нужна задержка - набрать тактов
            System.Threading.Thread.Sleep(10);
            sw.Stop();
            long Random = sw.ElapsedTicks;
            return (int)(Random % 100) + 1; // берутся два последни знака
        }

        static List<ulong> Task14(ulong n)
        {
            List<ulong> list = new List<ulong>();

            // 0 - автоморфное число, внесу его сразу, чтобы потом не отсеять
            list.Add(0);

            ulong check;
            for(ulong i = 1; i <= n; i++)
            {
                // цифру младшего разряда произведения определяют только младшие разряды множителей;
                // поэтому, (1) автоморфное число может иметь в малдшем разряде только 1, 5, 6, т.к. только они дают самих себя в
                //                                                                                 младшем разряде произведения;
                // 0 - как исключение, (2) любое неоднозначное число, оканчивающееся на 0, при возведении в квадрат в малдших
                //  разрядах будет иметь два нуля (легко заметить при умножении столбиком);
                // так из последовательности исключаются 7/10 чисел, которые точно не автоморфные;
                check = i % 10;
                if (check == 1 || check == 5 || check == 6)
                {
                    if (Support(i * i, i)) list.Add(i);
                    else continue;
                }
                else continue;
            }

            return list;
        }

        /// <summary>
        /// Вспомогательный метод поразрядного сравнения. Тут удобна рекурсия.
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        static bool Support(ulong temp, ulong i)
        {
            // условие конца рекурсии
            if (i == 0) return true;
            // поразрядное сравнение
            if (temp % 10 == i % 10) return Support(temp / 10, i / 10);
            else return false;
        }
    }
}
