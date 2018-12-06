using System;
using System.Reflection;

namespace Lesson_8
{
    partial class Program
    {
        /*
         * Томашевич
         * 
         * 1. С помощью рефлексии выведите все свойства структуры DateTime
         * */

        static void Task1()
        {
            Type type = typeof(DateTime);

            PropertyInfo[] pInfo = type.GetProperties();

            Console.WriteLine("Свойства DateTime:");

            for (int i = 0; i < pInfo.Length; i++)
            {
                Console.WriteLine(pInfo[i].ToString());
            }
        }
    }
}