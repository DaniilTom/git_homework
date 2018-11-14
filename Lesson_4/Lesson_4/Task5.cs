using System;
using System.IO;
using ArrayLib;


namespace Lesson_4
{
    partial class Program
    {
        static void Task5()
        {
            Console.WriteLine("Задача 5. Класс библиотченый TwoDArray.");

            TwoDArray twoDArr = new TwoDArray(10, -5000, 5000); // сначала использовать эту строку
            //TwoDArray twoDArr = new TwoDArray("twoDArray.txt"); // после создания файла можно использовать эту строку

            Console.WriteLine("Элементы массива: \n{0}", twoDArr.ToString());

            Console.WriteLine("Sum: " + twoDArr.Sum());
            Console.WriteLine("Sum Greater Then 1000: " + twoDArr.SumGreaterThen(1000));
            Console.WriteLine("Min: " + twoDArr.Min);
            Console.WriteLine("Max: " + twoDArr.Max);
            int row, column;
            twoDArr.MaxElementPosition(out row, out column);
            Console.WriteLine($"Max Element position: [{row}, {column}]");

            twoDArr.WriteInFile("twoDArray.txt");
        }
    }
}