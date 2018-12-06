using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ДЗ 5. Символы. Строки. Регулярные выражения.");

            int task = 1;
            do
            {
                Console.Write("\nВведите номер задачи (или 0 для выхода): ");
                task = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (task)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        //Console.WriteLine("Не готово");
                        break;
                    case 3:
                        Task3();
                        //Console.WriteLine("Не готово");
                        break;
                    case 4:
                        Task4();
                        //Console.WriteLine("Не готово");
                        break;
                    case 5:
                        //Task5();
                        break;
                }
            } while (task != 0);
        }
    }
}
