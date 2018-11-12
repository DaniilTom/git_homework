using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    partial class Program
    {
        static void Task2()
        {
            Random rnd = new Random();

            /********** в этом блоке создается массив и записывается в файл **************/
            int[] mas = new int[20];
            Console.WriteLine("\nМассив содержит:");
            for (int i = 0; i < mas.Length; Console.Write(mas[i++] + " "))
            {
                mas[i] = rnd.Next(-10000, 10000);
            }

            /********* следующий блок используется при считывании массива из файла**********/

            //int[] mas = StaticTask1.ReadArrayFromFile("array.txt");
            //Console.WriteLine("\nМассив содержит:");
            //for (int i = 0; i < mas.Length; Console.Write(mas[i++] + " ")) { }

            StaticTask1.StaticTask1Method(mas);
        }

        static class StaticTask1
        {
            static public void StaticTask1Method(int[] mas)
            {
                Console.Write("\nКоличество пар: ");

                int num = 0;
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    if ((mas[i] % 3 == 0) ^ (mas[i + 1] % 3 == 0)) num++;
                }
                Console.WriteLine(num);

                //  запись массива в файл, чтоб можно было воспользоваться методом ReadArrayFromFile;
                // можно закомментировать, если изначально массив получается путем считывания из файла,
                //  в противном случае в файл просто перезапишутся те же значения
                FileStream fstr = new FileStream("array.txt", FileMode.OpenOrCreate);
                BinaryWriter bw = new BinaryWriter(fstr);

                for (int i = 0; i < mas.Length; i++)
                {
                    bw.Write(mas[i]);
                }
                bw.Close();
            }

            // использовать только после создания файла (см. начало метода Task2())
            static public int[] ReadArrayFromFile(string fileName)
            {
                int[] mas = new int[20];
                using (FileStream fstr = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fstr)) //тут есть метод для считывания Int32
                    {
                        for (int i = 0; br.BaseStream.Position < br.BaseStream.Length; i++) mas[i] = br.ReadInt32();
                    }
                }
                return mas;
            }
        }
    }
}
