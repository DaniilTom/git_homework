using System;
using System.Collections.Generic;



namespace Lesson_4
{
    partial class Program
    {
        static void Task3()
        {
            Console.WriteLine("Задача 3. Класс библиотченый OneDArray.");

            ArrayLib.OneDArray odArr = new ArrayLib.OneDArray(10, -5000, 5000);

            Console.WriteLine("Элементы массива: " + odArr.ToString());
            Console.WriteLine("Min: " + odArr.Min);
            Console.WriteLine("Max: " + odArr.Max);
            Console.WriteLine("Count Positive: " + odArr.CountPositive);
            Console.WriteLine("Sum: " + odArr.Sum);
            Console.Write("Invers: ");
            foreach (var inverse in odArr.Inverse()) Console.Write(inverse + " ");
            odArr.Multi(2);
            Console.WriteLine();
            Console.WriteLine("Multi x2: " + odArr.ToString());
            Console.WriteLine("Max Count: " + odArr.MaxCount);

            Dictionary<int, int> d = odArr.ElementsInCount();
            Console.WriteLine("Elements In Count: \n{0, 8} {1, 8}", "Key", "Value");
            foreach (var elem in d) { Console.WriteLine("{0, 8} {1, 8}", elem.Key, elem.Value); }
        }
    }
}