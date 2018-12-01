using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_8
{
    public partial class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine("ДЗ 8. Рекурсия. Сериализация.");

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
                        //Task2();
                        Application.Run(new Form1());
                        //Console.WriteLine("См другой проект");
                        break;
                    case 3:
                        //Task3();
                        Console.WriteLine("См задание 4");
                        break;
                    case 4:
                        Console.WriteLine("Здесь используются формы: " +
                            "DataBase, SetPassword, AboutBox1.");
                        Application.Run(new DataBase());
                        //Console.WriteLine("Не готово");
                        break;
                    case 5:
                        Task5();
                        break;
                }
            } while (task != 0);
        }
    }
}
