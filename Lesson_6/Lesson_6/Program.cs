using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ДЗ 6. Делегаты, файлы, коллекции.");

            int task = 1;
            do
            {
                Console.Write("\nВведите номер задачи (или 0 для выхода): ");
                task = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (task)
                {
                    case 1:
                        //Task1();
                        Console.WriteLine("Не готово");
                        break;
                    case 2:
                        Task2();
                        //Console.WriteLine("Не готово");
                        break;
                    case 3:
                        //Task3();
                        Console.WriteLine("Не готово");
                        break;
                    case 4:
                        Task4();
                        //Console.WriteLine("Не готово");
                        break;
                    case 5:
                        //Task5();
                        Console.WriteLine("Не готово");
                        break;
                }
            } while (task != 0);
        }
    }
}
