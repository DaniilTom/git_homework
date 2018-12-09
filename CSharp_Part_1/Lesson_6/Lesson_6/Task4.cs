using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    partial class Program
    {
        /*
         * Томашевич
         * 
         * **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”.
         * Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader
         *  и массив int для BinaryReader.
         *  */

        static void Task4()
        {
            Console.WriteLine("Задача №4. Считывание файлов разными способами. Поставьте точки останова в блоке " +
                "try, чтобы посмотреть результаты считывания, представленные в разном виде.");
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = mbyte;
            //Read FileStream
            //Read BinaryStream
            //Read StreamReader/StreamWriter
            //Read BufferedStream
            try
            {
                // тут можно поставить точки останова и посмотреть данные
                byte[] bt = FileStreamSample("bigdata0.bin", size);
                int[] iNt = BinaryStreamSample("bigdata1.bin", size);
                string str = StreamReaderSample("bigdata2.bin", size);
                byte[] bte = BufferedStreamSample("bigdata3.bin", size);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"Файл {ex.FileName} не обнаружен.");
            }
            /*Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample("bigdata0.bin", size));
            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample("bigdata1.bin", size));
            Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamReaderSample("bigdata2.bin", size));
            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample("bigdata3.bin", size));*/

            Console.ReadKey();
        }

        static byte[] FileStreamSample(string filename, long size)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if (fs.Length < size) size = fs.Length;
            byte[] @out = new byte[size];
            fs.Read(@out, 0, (int) size); //безопасное приведение к int, пока используются малые разеры данных (до 4 Гб)
            fs.Close();                     // хотя все-равно нельзя создавать массивы размеров больше 2 Гб
            return @out;
        }

        static int[] BinaryStreamSample(string filename, long size)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            size = size / sizeof(int); // байты -> количество чисел типа int
            if (fs.Length / sizeof(int) < size) size = fs.Length / sizeof(int);
            int[] @out = new int[size];
            for (int i = 0; i < size; i++)
                @out[i] = br.ReadInt32();   // считывается int, за раз Position смещается на 4 байта
            fs.Close();
            return @out;
        }

        static string StreamReaderSample(string filename, long size)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            size = size / sizeof(char);     // byte -> количество символов char
            char[] @out = new char[size];
            sw.Read(@out, 0, (int)size);    // считывается char, за раз Position смещается на 2 байта
            fs.Close();
            return new String(@out);
        }

        static byte[] BufferedStreamSample(string filename, long size)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BufferedStream bs = new BufferedStream(fs, 4096);
            if (fs.Length < size) size = fs.Length;
            byte[] @out = new byte[size];
            bs.Read(@out, 0, (int) size);
            fs.Close();

            return @out;
        }
    }
}
