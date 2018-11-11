using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    partial class Program
    {
        /*
         * Томашевич
         * Задание 3
         * */

        static void Main(string[] args)
        {
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
                        break;

                    case 3:
                        Task3();
                        break;
                }

            } while (task != 0);

                //Console.ReadLine();
        }
    }
}
