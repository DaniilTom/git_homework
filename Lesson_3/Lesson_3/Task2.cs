using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    /*  Томашевич
     * а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
     * Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран,
     * используя tryParse.
     * */

    partial class Program
    {
        static void Task2()
        {
            Console.WriteLine("Задача 2. Сумма нечетных пложительных чисел.");

            List<int> listNumber = new List<int>();
            int n;
            for(; ;)
            {
                n = GetValue("Введите число: ");
                if (n == 0) break;
                listNumber.Add(n);
            }

            Console.WriteLine("Введенные числа: ");
            int sum;
            for(int i = 0; i < listNumber.Count; i++)
            {

            }
        }

        static int GetValue(string message)
        {
            int x;
            string s;
            bool flag;       // Логическая переменная, выступающая в роли "флага".
                             // Истинно (флаг поднят), ложно (флаг опущен)
            do
            {
                Console.Write(message);
                s = Console.ReadLine();
                //  Если перевод произошел неправильно, то результатом будет false
                flag = int.TryParse(s, out x);
            }
            while (!flag);  //  Пока false(!false=true), повторять цикл
            return x;
        }

    }
}
