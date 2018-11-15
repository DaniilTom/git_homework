
namespace Lesson_5
{
	partial class Programm
	{
		/* Томашевич
		Создать программу, которая будет проверять корректность ввода логина.
		Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
		при этом цифра не может быть первой:
			а) без использования регулярных выражений;
			б) **с использованием регулярных выражений.
			*/
		static void Task1()
		{
			Console.WriteLine("Задача 1. Проверка логина.");
			Сonsole.WriteLine("Использовать регулярные выражения? [Y / N] ");
			string ans = Console.ReadLine();

			if(ans.ToLower() == 'N')
			{
				do
				{
					bool correct = true;

					Console.Write("Введите логин: ");
					string login = Console.ReadLine();

					string result = "";

					if(login.Length > 10) result += "Пароль слишком длинный. ";
					else if (login.Length < 2) result += "Пароль слишком короткий. ";

					for(int i = 0; i < login.Length; i++)
					{
						if(login[i].IsDigit())
						{
							if(i != 0) continue;
							else 
							{
								result += "Первый символ не должен быть цифрой. ";
								correct = false;
							}
						}

						if(	login[i].IsLetter() &&
							((login[i] >= 'A' && login[i] <= 'Z') ||
							 (login[i] >= 'a' && login[i] <= 'z')) continue;
						else
						{
							result += "Обнаружен(ы) символ(ы) не латинского алфавита."
							correct = false;
							break;
						}
					}
					
				} while(!correct);
			}
			else
			{
				Regex reg = new Regex("[A-Za-z]{1}[A-Za-z0-9]{1,9}");

				bool correct = true;

				do
				{
					Console.Write("Введите логин: ");
					string login = Console.ReadLine();
					correct = reg.IsMatch(login);
					if(!correct) Console.WriteLine("Логин не удвлетворяет требованиям.");

				} while(!correct);
			}

			if(!correct) Console.WriteLine(result);
					else Console.WriteLine("Логин верный.");
		}
	}
}