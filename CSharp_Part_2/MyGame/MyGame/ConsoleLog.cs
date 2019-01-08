using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    static class ConsoleLog
    {
        static bool isOpened = false;

        /// <summary>
        /// Открывает консоль.
        /// </summary>
        public static void OpenConsoleLog()
        {
            if (isOpened) return;
            AllocConsole();
            Console.WriteLine("Log begins:\n");
            isOpened = true;
        }
        
        /// <summary>
        /// Закрывает консоль.
        /// </summary>
        public static void CloseConsoleLog()
        {
            if (!isOpened) return;
            Console.WriteLine("\nLog ends.");
            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
            FreeConsole();
        }

        // опишим методы, удвлетворяющие сигнатуре делегатов в классе Ship
        /// <summary>
        /// Вызывается при уничтожении <see cref="Ship"/>. Автоматически вызывает <see cref="CloseConsoleLog()"/>.
        /// Сигнатура совпадает с делегатом <see cref="Ship.MessageDie"/>.
        /// </summary>
        public static void ShipDestroyed()
        {
            Console.WriteLine("Корабль уничтожен.");
            CloseConsoleLog();
        }

        /// <summary>
        /// Отмечает получение повреждений.
        /// </summary>
        /// <param name="damage"></param>
        public static void ShipDamaged(int damage)
        {
            Console.WriteLine($"Корабль получил повреждение: -{damage} hp;");
        }

        /// <summary>
        /// Отмечает получение лечений.
        /// </summary>
        /// <param name="heal"></param>
        public static void ShipHealed(int heal)
        {
            Console.WriteLine($"Корабль получил лечение: +{heal} hp;");
        }


        // добавим консоль для логов
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();
    }
}
