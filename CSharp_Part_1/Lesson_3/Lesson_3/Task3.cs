using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    /*
     * Томашевич
     * 
     * 
     * *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
     *      Предусмотреть методы сложения, вычитания, умножения и деления дробей.
     *      Написать программу, демонстрирующую все разработанные элементы класса.
     * * Добавить свойства типа int для доступа к числителю и знаменателю;
     * * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
     * ** Добавить проверку, чтобы знаменатель не равнялся 0.
     *      Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
     * *** Добавить упрощение дробей.
     * */

    partial class Program
    {
        static void Task3()
        {
            Console.WriteLine("Задача 3. Класс дробей (Fraction).");

            Console.Write("Введите числитель первой дроби: ");
            int fr1Num = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель первой дроби: ");
            int fr1Denum = int.Parse(Console.ReadLine());
            Console.Write("Введите числитель второй дроби: ");
            int fr2Num = int.Parse(Console.ReadLine());
            Console.Write("Введите знаменатель второй дроби: ");
            int fr2Denum = int.Parse(Console.ReadLine());

            Fraction fr1 = new Fraction(fr1Num, fr1Denum);
            Fraction fr2 = new Fraction(fr2Num, fr2Denum);

            Console.WriteLine("Примеры работы");
            Console.WriteLine("Дробь 1 после сокращения: {0}", fr1.ToString());
            Console.WriteLine("Дробь 2 после сокращения: {0}", fr2.ToString());

            Console.WriteLine("Результат сложения дробей: {0}", fr1 + fr2);
            Console.WriteLine("Результат вычитания дробей: {0}", fr1 - fr2);
            Console.WriteLine("Результат умножения дробей: {0}", fr1 * fr2);
            Console.WriteLine("Результат деления дробей: {0}", fr1 / fr2);
        }

        class Fraction
        {
            int numerator;
            int denumerator;

            public Fraction(int _numerator, int _denominator)
            {
                Num = _numerator;
                Denum = _denominator;
                Reduction(); //сразу сократить
            }

            /// <summary>
            /// Свойство для работы с числителем.
            /// </summary>
            public int Num
            {
                set { numerator = value; }
                get { return numerator; }
            }

            /// <summary>
            /// Свойство для работы с знаменателем.
            /// </summary>
            public int Denum
            {
                set
                {
                    if (value == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
                    denumerator = value;
                }
                get { return denumerator; }
            }

            /// <summary>
            /// Функция сокращения дроби.
            /// </summary>
            /// <param name="_num">Числитель</param>
            /// <param name="_denum">Знаменатель</param>
            private void Reduction()
            {
                int gcd = GCD(Math.Abs(numerator), Math.Abs(denumerator));
                numerator /= gcd;
                denumerator /= gcd;
            }

            /// <summary>
            /// Алгоритм Евклида для поиска НОД двух чисел
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            private int GCD(int a, int b)
            {
                if (a == 0) return b;
                if (b == 0) return a;

                if (a <= b) return GCD(b % a, a);
                else return GCD(a % b, b);
            }

            /// <summary>
            /// Перегрузка оператора "+" для Fraction
            /// </summary>
            /// <param name="fr1"></param>
            /// <param name="fr2"></param>
            /// <returns></returns>
            public static Fraction operator +(Fraction fr1, Fraction fr2)
            {
                int newNum, newDenum;

                newDenum = fr1.Denum * fr2.Denum; // проще "в лоб", чем искать доп. множители, потом все равно сократится
                newNum = fr1.Num * fr2.Denum + fr2.Num * fr1.Denum;
                return new Fraction(newNum, newDenum);
            }

            /// <summary>
            /// Перегрузка оператора "-" для Fraction
            /// </summary>
            /// <param name="fr1"></param>
            /// <param name="fr2"></param>
            /// <returns></returns>
            public static Fraction operator -(Fraction fr1, Fraction fr2)
            {
                int newNum, newDenum;

                newDenum = fr1.Denum * fr2.Denum; // проще "в лоб", чем искать доп. множители, потом все равно сократится
                newNum = fr1.Num * fr2.Denum - fr2.Num * fr1.Denum;
                return new Fraction(newNum, newDenum);
            }

            /// <summary>
            /// Перегрузка оператора "*" для Fraction
            /// </summary>
            /// <param name="fr1"></param>
            /// <param name="fr2"></param>
            /// <returns></returns>
            public static Fraction operator *(Fraction fr1, Fraction fr2)
            {
                return new Fraction(fr1.Num * fr2.Num,
                                    fr1.Denum * fr2.Denum);
            }

            /// <summary>
            /// Перегрузка оператора "/" для Fraction
            /// </summary>
            /// <param name="fr1"></param>
            /// <param name="fr2"></param>
            /// <returns></returns>
            public static Fraction operator /(Fraction fr1, Fraction fr2)
            {
                return new Fraction(fr1.Num * fr2.Denum,
                                    fr1.Denum * fr2.Num);
            }

            /// <summary>
            /// Возвращет десятичное представление дроби.
            /// </summary>
            public double DecimalView
            {
                get { return (double)Num / Denum; }
            }

            public override string ToString()
            {
                return ((Num < 0 ^ Denum < 0) ? "-" : "") + Math.Abs(Num) + "/" + Math.Abs(Denum);
            }
        }
    }
}
