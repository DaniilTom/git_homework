using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSVReader
{
    // ПРИМЕЧАНИЕ: кол-во считанных строк м.б. быть меньше. После того, как пересохранил файл, кол-во читаемых строк
    //  изменилось, но все еще меньше, чем есть (как буд-то после сохранения немного и

    // ПРИМЕЧАНИЕ 2: считывание файла без разбиения также дает меньшее кол-во строк (см. стр. 39-45)

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Началась загрузка CSV файла в два потока.");

            FileInfo fi = new FileInfo("Data.csv");

            long div = fi.Length / 2;

            Thread thrd1 = new Thread(CSVPartReader);
            Thread thrd2 = new Thread(CSVPartReader);

            thrd1.Start((long)0);
            thrd2.Start(div);

            thrd1.Join();
            thrd2.Join();

            List<string> list = new List<string>();

            list.AddRange(list_1);
            list.AddRange(list_2);

            //List<string> list = new List<string>();

            //using (StreamReader sr = new StreamReader(new FileStream("Data.csv", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    sr.BaseStream.Position = 0;
            //    while (sr.BaseStream.Position < sr.BaseStream.Length) list.Add(sr.ReadLine());
            //}

            Console.ReadLine();

        }

        static List<string> list_1 = new List<string>();
        static List<string> list_2 = new List<string>();

        private static void CSVPartReader(object start_pos)
        {

            using (StreamReader sr = new StreamReader(new FileStream("Data.csv", FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                long start = (long)start_pos;
                sr.BaseStream.Position = start;

                long end;

                if (start == 0)
                {
                    end = sr.BaseStream.Length / 2; // файл делится на две части

                    while (sr.BaseStream.Position <= end)
                    {
                        list_1.Add(sr.ReadLine());
                    }
                }
                else
                {
                    // т.к. при делении можно попасть в середину строки, то просто считаем ее и выкинем;
                    // нормально она будет считана в том потоке, который считывает первую часть
                    sr.ReadLine();
                    end = sr.BaseStream.Length;
                    while (sr.BaseStream.Position < end)
                    {
                        list_2.Add(sr.ReadLine());
                    }
                }
            }
        }
    }
}
