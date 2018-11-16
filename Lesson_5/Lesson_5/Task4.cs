using System;

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
			int studentsNum = 10;

			Student[] stdnts = new Student[studentsNum];

			string[] exampleLines = {	"Иванов Петр 4 5 3",
										"Петров Иван 5 5 5",
										"Павлов Александр 3 3 3",
										"Смирнов Максим 4 4 4",
										"Васильев Артем 5 3 3",
										"Попов Никита 4 4 5",
										"Соколов Дмитрий 4 5 3",
										"Михайлов Егор 3 5 4",
										"Федоров Михаил 4 5 3",
										"Морозов Алексей 5 5 4"};

			for(int i = 0; i < exampleLines.Length; i++)
			{
				stdnts[i] = new Student(exampleLines[i]);
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