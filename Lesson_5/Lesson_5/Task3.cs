using System;

namespace Lesson_5
{
	partial class Program
	{
		static void Task3()
		{
			Console.WriteLine("Задача 3. Тест на \"перестановку\"");

			Console.Write("Введите первую строку: ");
			string str1 = Console.ReadLine();
			Console.Write("Введите вторую строку: ");
			string str2 = Console.ReadLine();

			Console.WriteLine("Строки {0}являются \"перестановками\"",
				IsPermutation(str1, str2) ? "" : "не ");
		}
		public static bool IsPermutation(string str1, string str2)
		{
			if(str1.Length != str2.Length) return false;

			for(int i = 0; i < str1.Length; i++)
			{
				if(!str1.Contains(str2[i].ToString()) || !str2.Contains(str1[i].ToString())) return false;
			}

			return true;
		}
	}
}