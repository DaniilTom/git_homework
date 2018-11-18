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
            SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;

        }
    }
}

