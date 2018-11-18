using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    partial class Program
    {
        /*
         * Томашевич
         * 
         * Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
         * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
         * */

        static void Task1()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Console.WriteLine("Таблица функции a * Sin:");
            Table(ASin, 10, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции a*x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double a, double x) { return a * x * x; }, 1, 0, 3);

        }

        public delegate double Fun(double a, double x);

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F,double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        // Создаем метод для передачи его в качестве параметра в Table
        /*public static double AX2(double a, double x)
        {
            return a * x * x;
        }*/

        public static double ASin(double a, double x)
        {
            return a * Math.Sin(x);
        }


    }
}
