using System;
using System.IO;

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

	class TwoDArray
	{
		int[,] a;

        public TwoDArray(int n,int el)
        {
            a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = el;
        }
        public TwoDArray(int n, int min,int max)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(min,max);
        }

        /***************** конструкто для загрузки из файла *****/
        public TwoDArray(string fileName)
        {
        	FileStream fstr = null;
        	BinaryReader br = null;
        	try
        	{
        		fstr = new FileStream(fileName, FileMode.Open);
        		br = new BinaryReader(fstr);
                int size = (int) Math.Sqrt(fstr.Length);

                a = new int[size, size];

        		for(int i = 0; i < Math.Sqrt(fstr.Length); i++)
        			for(int j = 0; j < Math.Sqrt(fstr.Length); j++)
        				a[i,j] = br.ReadInt32();
        	}
        	catch(FileNotFoundException)
        	{
        		Console.WriteLine("Файл не найден.");
        		throw;  //чтобы предотвратить создание объекта TwoDArray
        	}
        	finally
        	{
        		br.Close();
        	}
        }

        /**************** метод записи в файл ********/
        public void WriteInFile(string fileName)
        {
        	FileStream fstr = new FileStream(fileName, FileMode.OpenOrCreate);
        	BinaryWriter bw = new BinaryWriter(fstr);

        	for(int i = 0; i < a.Length; i++)
        			for(int j = 0; j < a.Length; j++)
        				bw.Write(a[i,j]);

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
                // Свойство - подсчет количества положительных
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
                // Свойство - подсчет среднего арифметического
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum+=a[i,j];
                return sum/a.GetLength(0)/a.GetLength(1);
            }

        }

        /****************** сумма всех элементов массива ******/
        public int Sum()
        {
        	int sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum += a[i, j];
                return sum;
        }

        /****************** сумма всех элементов массива больше заданного******/
        public int SumGreaterThen(int key)
        {
        	int sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if(a[i, j] > key) sum += a[i, j];
                return sum;
        }
             // Метод, который возвращает массив в виде строки
        public override string ToString()
        {
            string s="";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j] + " ";
                s += "\n"; // Переход на новую строчку

            }
            return s;
        }
    }
}