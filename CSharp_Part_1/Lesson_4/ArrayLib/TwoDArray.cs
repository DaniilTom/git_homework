using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLib
{
    /*
		Томашевич
	*а) Реализовать библиотеку с классом для работы с двумерным массивом.
		Реализовать конструктор, заполняющий массив случайными числами.
		Создать методы, которые возвращают сумму всех элементов массива,
		сумму всех элементов массива больше заданного, свойство,
		возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
		возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
	**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
	**в) Обработать возможные исключительные ситуации при работе с файлами.
	*/

    public class TwoDArray
    {
        int[,] a;

        public TwoDArray(int n, int el)
        {
            a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = el;
        }
        public TwoDArray(int n, int min, int max)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(min, max);
        }

        /// <summary>
        /// Конструктор для загрузки массива из файла.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public TwoDArray(string fileName)
        {
            FileStream fstr = null;
            BinaryReader br = null;
            try
            {
                fstr = new FileStream(fileName, FileMode.Open);
                br = new BinaryReader(fstr);
                int size = (int)Math.Sqrt(fstr.Length / sizeof(int));

                a = new int[size, size];

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        a[i, j] = br.ReadInt32();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
                throw;  //чтобы предотвратить создание объекта TwoDArray
            }
            finally
            {
                br.Close();
            }
        }

        /// <summary>
        /// Метода записи массива в файл.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void WriteInFile(string fileName)
        {
            FileStream fstr = new FileStream(fileName, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fstr);

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    bw.Write(a[i, j]);

            bw.Close();
        }

        public int Min
        {
            get
            {
                int min = a[0, 0];
                // Находим минимальный элемент
                // В двухмерном массиве для получения размерности нужно использовать
                // метод GetLength, а в скобках указывать измерение
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }

        /// <summary>
        /// Находит позицию первого максимального элемента.
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="column">Столбец</param>
        public void MaxElementPosition(out int row, out int column)
        {
            int max = a[0, 0];
            row = 0;
            column = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        row = i;
                        column = j;
                    }
        }


        /// <summary>
        /// Подсчет количества положительных элементов.
        /// </summary>
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > 0) count++;
                return count;
            }
        }

        /// <summary>
        /// Расчет среднего арифметического.
        /// </summary>
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum += a[i, j];
                return sum / a.GetLength(0) / a.GetLength(1);
            }

        }

        /// <summary>
        /// Расчет суммы всех элементов массива.
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];
            return sum;
        }

        /// <summary>
        /// Расчет суммы всех элементов, больше заданного порога.
        /// </summary>
        /// <param name="key">Порог</param>
        /// <returns></returns>
        public int SumGreaterThen(int key)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > key) sum += a[i, j];
            return sum;
        }
        // Метод, который возвращает массив в виде строки
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    str.AppendFormat("{0, 7}", a[i,j]);//
                str.Append("\n"); // Переход на новую строчку

            }
            return str.ToString();
        }
    }
}