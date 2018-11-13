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


namespace ArrayLib //вместо библиотеки
{
	/*
     *  Томашевич
	а) Дописать класс для работы с одномерным массивом. Реализовать конструктор,
	создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
		Создать свойство Sum, которое возвращает сумму элементов массива, 
		метод Inverse, возвращающий новый массив с измененными знаками у всех элементов
		массива (старый массив, остается без изменений), 
		метод Multi, умножающий каждый элемент массива на определённое число, 
		свойство MaxCount, возвращающее количество максимальных элементов. 
	б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
	е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
	*/

	class OneDArray
	{
		int[] a;
        //  Создание массива и заполнение его одним значением el  
        public OneDArray(int n,int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        //  Создание массива и заполнение его случайными числами от min до max
        public OneDArray(int n, int min,int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min,max);
        }
        public int Max
        {
            get 
            { 
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }

        /// <summary>
        /// Вычисляет сумму всех элементов.
        /// </summary>
        public int Sum
        {
        	get
        	{
        		int sum = 0;

        		for(int i = 0; i < a.Length; sum += a[i++]){}

        		return sum;
        	}
        }

        /// <summary>
        /// Возвращает массив, элементы которого инвертированы.
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
        	int[] b = new int[a.Length];
        	for(int i = 0; i < a.Length; i++)
        	{
        		b[i] = -a[i];
        	}

        	return b;
        }

        /// <summary>
        /// Умножает все элементы массива на gain.
        /// </summary>
        /// <param name="gain">Множитель</param>
        public void Multi(int gain)
        {
        	for(int i = 0; i < a.Length; i++)
        	{
        		a[i] = gain * a[i];
        	}
        }

        /// <summary>
        /// Определяет, сколько раз встречается максимальное значение.
        /// </summary>
        public int MaxCount
        {
        	get
        	{
        		int key = this.Max;
	        	int num = 0;
	        	for(int i = 0; i < a.Length; i++)
	        	{
	        		if(a[i] == key) num++;
	        	}
	        	return num;
        	}
        }

        /// <summary>
        /// Подсчитывает частоту вхождения символов.
        /// </summary>
        /// <returns>Содержит в TKey значение элемента и в TValue частоту вхождения</returns>
        public Dictionary<int, int> ElementsInCount()
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            
        	for(int i = 0; i < a.Length; i++)
        	{
        		if(d.ContainsKey(a[i])) d[a[i]]++;
        		else d.Add(a[i], 1);
        	}

        	return d;
        } 

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s=s+v+" ";
            return s;
        }

	}
}