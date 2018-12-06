using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    partial class Program
    {
        /*  Томашевич
         * 
         * Дан  целочисленный  массив  из 20 элементов.
         * Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно.
         * Заполнить случайными числами.  Написать программу, позволяющую найти и
         *  вывести количество пар элементов массива, в которых только одно число делится на 3.
         * В данной задаче под парой подразумевается два подряд идущих элемента массива.
         * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
         * */

        static void Task1()
        {
            int[] mas = new int[20];

            Random rnd = new Random();

            Console.WriteLine("\nМассив содержит:");
            for(int i = 0; i < mas.Length; Console.Write(mas[i++] + " "))
            {
                mas[i] = rnd.Next(-10000, 10000);
            }

            Console.Write("\nКоличество пар: ");

            int num = 0;
            for(int i = 0; i < mas.Length - 1; i++)
            {
                if ((mas[i] % 3 == 0) ^ (mas[i + 1] % 3 == 0)) num++;
            }
            Console.WriteLine(num);

        }
    }
}
