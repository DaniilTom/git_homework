using System;
using System.IO;

namespace Lesson_5
{
	partial class Program
	{
		/*	Томашевич
		*Задача ЕГЭ.
		На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
		В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
		каждая из следующих N строк имеет следующий формат:
			<Фамилия> <Имя> <оценки>,
		где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка,
		состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа,
		соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки>
		разделены одним пробелом. 
		Пример входной строки:
			Иванов Петр 4 5 3
		Требуется написать как можно более эффективную программу, которая будет выводить на экран
		фамилии и имена трёх худших по среднему баллу учеников. 
		Если среди остальных есть ученики, набравшие тот же средний балл, 
		что и один из трёх худших, следует вывести и их фамилии и имена.
*/
		public static void Task4()
		{
            // В этом фрагменте кода идет считывание данных из консоли.
            // закомментируйте строки 30 - 38, и раскомментируйте 42 - 53 чтобы использовать готовые данные.
            // Начнем вводить данные в поток.
            Console.WriteLine("Сначала кол-во учеников, затем их данные в формате\n" +
                "<Фамилия> <Имя> <оценка1> <оценка2> <оценка3>.\n" +
                "Когда все данные будут введены, нажмите CTRL + Z и нажмите Enter.");
            // Предположим, что все данные уже помещены в поток. Чтаем их все.
            string allInputData = Console.In.ReadToEnd();
            // Каждый кортеж расположен на своей строке. Используем разбиение на строки с разделителем NewLine.
            string[] exampleLines = allInputData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // Первым идет количество учеников.
            byte studentsNum = Byte.Parse(exampleLines[0]);



            //  byte studentsNum = 10;
            //  string[] exampleLines = {   "10",
            //                              "Иванов Петр 4 5 3",
            //"Петров Иван 5 5 5",
            //"Павлов Александр 3 3 3",
            //"Смирнов Максим 4 4 4",
            //"Васильев Артем 5 3 3",
            //"Попов Никита 4 4 5",
            //"Соколов Дмитрий 4 5 3",
            //"Михайлов Егор 3 5 4",
            //"Федоров Михаил 4 5 3",
            //"Морозов Алексей 5 5 4"};

            // Теперь заполним масиив Student[] данными
            Student[] stdnts = new Student[studentsNum];

            for (int i = 0; i < exampleLines.Length - 1; i++)
			{
				stdnts[i] = new Student(exampleLines[i+1]);
			}

			Array.Sort(stdnts, delegate(Student std1, Student std2)
			{
				return std1.average.CompareTo(std2.average);
				});

			float threshold = stdnts[2].average;

			Console.WriteLine("Низкий средний бал у следующих учеников:");

			for(int i = 0; i < studentsNum; i++)
			{
				if(stdnts[i].average <= stdnts[2].average)
				Console.WriteLine($"{stdnts[i].secondName, 20} {stdnts[i].firstName, 20}   {stdnts[i].average,-5:0.##}");
				else break;
			}
		}

		struct Student
		{
			public string firstName, secondName;
			byte mark1, mark2, mark3;
			public float average;

			public Student(string line)
			{
				string[] info = line.Split(' ');
				
				secondName = info[0];
				firstName = info[1];
				mark1 = byte.Parse(info[2]);
				mark2 = byte.Parse(info[3]);
				mark3 = byte.Parse(info[4]);

				average = (float) (mark1 + mark2 + mark3) / 3;
			}
		}
	}
}