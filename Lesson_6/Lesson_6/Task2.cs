using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    /*
     * Томашевич
     * 
     * Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
        а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и
            на каком отрезке находить минимум. Использовать массив (или список) делегатов,
            в котором хранятся различные функции.
        б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
            Пусть она возвращает минимум через параметр (с использованием модификатора out). 
            */

    partial class Program
    {
        static void Task2()
        {
            FuncDelegate[] fd = new FuncDelegate[3];

            fd[0] = new FuncDelegate(F2);
            fd[1] = EXP;
            fd[2] = LogDec;

            int func = 0;

            Console.Write("\nВыберите ф-ию (1 - полином 2-ой степени, 2 - экспонента, 3 - Log10): ");
            func = Int32.Parse(Console.ReadLine());

            Console.Write("\nВведите диапазон и шаг через пробел (min max delta): ");
            string[] data = Console.ReadLine().Split(' ');

            SaveFunc("data.bin", double.Parse(data[0]),
                                    double.Parse(data[1]),
                                    double.Parse(data[2]), fd[func-1]);
            double min;
            double[] mas = Load("data.bin", out min);
            Console.WriteLine($"Минимальное значение: {min}");
            Console.WriteLine("Рассчитанные значения: ");
            foreach(var d in mas)
            {
                Console.WriteLine(d.ToString());
            }
            Console.ReadKey();
        }

        public delegate double FuncDelegate(double x);

        /// <summary>
        /// Полином x^2 - 50*x + 10.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double F2(double x)
        {
            return x * x - 50 * x + 10;
        }

        /// <summary>
        /// Экспоненциальная ф-ия e^x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double EXP(double x)
        {
            return Math.Pow(Math.E, x);
        }

        /// <summary>
        /// Десятичный логарифм Log10().
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double LogDec(double x)
        {
            return Math.Log10(x);
        }

        public static void SaveFunc(string fileName, double a, double b, double h, FuncDelegate f)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] d = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d[i] = bw.ReadDouble();
                if (d[i] < min) min = d[i];
            }
            bw.Close();
            fs.Close();
            return d;

        }
    }
}

