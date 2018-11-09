using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    /* Томашевич
     * 
     * 1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
     *    б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
     *    в) Добавить диалог с использованием switch демонстрирующий работу класса.
     * */
    partial class Program
    {
        static void Task1()
        {
            Console.WriteLine("Задача 1. Работа с классом Complex.");

            Complex complex1 = new Complex(1, 1);
            Complex complex2 = new Complex(3, 3);

            Console.WriteLine("Число №1: Re = {0}, Im = {1}", complex1.Re, complex1.Im);
            Console.WriteLine("Число №2: Re = {0}, Im = {1}", complex2.Re, complex2.Im);

            Console.Write("Что сделать (add, mul, sub): ");
            string action = Console.ReadLine().ToLower();

            string answer = "Результат ";
            switch(action)
            {
                case "add":
                    answer += "сложения: ";
                    answer += complex1.Plus(complex2);
                    break;
                case "mul":
                    answer += "умножения: ";
                    answer += complex1.Multiply(complex2);
                    break;
                case "sub":
                    answer += "вычитания: ";
                    answer += complex1.Minus(complex2);
                    break;
                default:
                    Console.WriteLine("Не понял");
                    break;
            }

            Console.WriteLine(answer);
        }

        class Complex
        {
            // Поля приватные.
            private double im;
            // По умолчанию элементы приватные, поэтому private можно не писать.
            double re;

            // Конструктор без параметров.
            public Complex()
            {
                im = 0;
                re = 0;
            }

            // Конструктор, в котором задаем поля.    
            // Специально создадим параметр re, совпадающий с именем поля в классе.
            public Complex(double _im, double re)
            {
                // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
                im = _im;
                // Чтобы показать, что к полю нашего класса присваивается параметр,
                // используется ключевое слово this
                // Поле параметр
                this.re = re;
            }
            public Complex Plus(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.im + im;
                x3.re = x2.re + re;
                return x3;
            }
            // **********************************************Добавлено вычитание
            public Complex Minus(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.im - im;
                x3.re = x2.re - re;
                return x3;
            }
            // **********************************************Добавлено умножение
            public Complex Multiply(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.im * im;
                x3.re = x2.re * re;
                return x3;
            }
            // Свойства - это механизм доступа к данным класса.
            public double Im
            {
                get { return im; }
                set
                {
                    if(value >= 0) im = value;
                }
            }

            public double Re
            {
                get { return re; }
                set
                {
                    if(value >= 0) re = value;
                }
            }
            // Специальный метод, который возвращает строковое представление данных.
            public override string ToString()
            {
                return re + "+" + im + "i";
            }
        }

    }
}
