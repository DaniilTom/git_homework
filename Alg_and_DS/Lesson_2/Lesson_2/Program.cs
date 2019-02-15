using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FromDecimalToBin(250));
            Console.WriteLine("Просто:" + Power(2, 5));
            Console.WriteLine("С рекурсией: " + PowerWithRec(2, 5));
            Console.WriteLine("С четнсотью: " + PowerWithRecWithParity(2, 5));

            Calc(20, 3);

            Console.ReadLine();

        }


        /// <summary>
        /// Перевод из десятичной в двоичную
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static string FromDecimalToBin(int a)
        {
            if (a == 0) return "";
            else return FromDecimalToBin(a / 2) + (a % 2).ToString();
        }


        /// <summary>
        /// Простое возведение в сетпень
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sup"></param>
        /// <returns></returns>
        static long Power(int num, int sup)
        {
            if (sup == 0)
            {
                if (num == 0) throw new ArgumentNullException("Неопределенность 0^0");
                else return 1;
            }

            long result = num;
            for (int i = 1; i < sup; i++)
            {
                result *= num;
            }
            return result;
        }

        /// <summary>
        /// Возведение через рекурсию
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sup"></param>
        /// <returns></returns>
        static long PowerWithRec(int num, int sup)
        {
            if (sup == 0)
            {
                if (num == 0) throw new ArgumentNullException("Неопределенность 0^0");
                else return 1;
            }

            return num * PowerWithRec(num, sup-1);
        }

        /// <summary>
        /// Со свойством четности
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sup"></param>
        /// <returns></returns>
        static long PowerWithRecWithParity(int num, int sup)
        {
            if (sup == 0)
            {
                if (num == 0) throw new ArgumentNullException("Неопределенность 0^0");
                else return num;
            }

            if (sup % 2 == 0)   return num * PowerWithRecWithParity(num, sup / 2);
            else                return num * PowerWithRecWithParity(num, sup - 1);
        }


        /// <summary>
        /// Строит дерево перехода от числа pos до числа num через действия +1 и *2. Как прорисовать вертикальные 
        /// лини - не придумал.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="pos"></param>
        static void Calc(int num, int pos=1)
        {

            if (pos == 0) pos++; //умножать 0 на 2 не имеет смысла
            
            Console.Write(pos);

            int cL = Console.CursorLeft - 1;

            if (pos < num) Console.Write("-");
            else return;

            Calc(num, pos+1);

            if (pos * 2 <= num)
            {
                Console.CursorLeft = cL;
                if (pos * 2 != num) Console.Write("|");
                Console.CursorTop += 1;
                Console.Write("\\");
                Console.CursorTop += 1;
                Calc(num, pos * 2);
            }
        }
    }
}
