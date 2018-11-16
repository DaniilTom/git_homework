
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson_5
{
	partial class Program
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
			Console.WriteLine("Использовать регулярные выражения? [Y / N] ");
			string ans = Console.ReadLine();

            bool correct;
            string result;

            if (ans.ToUpper() == "N")
			{
				do
				{
                    result = "";
                    correct = true;

					Console.Write("Введите логин: ");
                    string login = Console.ReadLine();
					

                    if(!(login.Length >= 2 && login.Length <= 10))
                    {
                        correct = false;
                        if (login.Length > 10) result += "Пароль слишком длинный. ";
                        else if (login.Length < 2) result += "Пароль слишком короткий. ";
                    }

					for(int i = 0; i < login.Length; i++)
					{
						if(char.IsDigit(login[i]))
						{
							if(i != 0) continue;
							else 
							{
								result += "Первый символ не должен быть цифрой. ";
								correct = false;
                                continue;
							}
						}

						if(	char.IsLetter(login[i]) &&
							((login[i] >= 'A' && login[i] <= 'Z') ||
							 (login[i] >= 'a' && login[i] <= 'z'))) continue;
						else
						{
                            result += "Обнаружен(ы) символ(ы) не латинского алфавита.";
							correct = false;
							break;
						}
					}

                    if (!correct) Console.WriteLine(result);

                } while(!correct);
			}
			else
			{
				//Regex reg = new Regex(@"[A-Za-z]{1}[A-Za-z0-9]{1,9}");
                correct = true;

				do
				{
					Console.Write("Введите логин: ");
					string login = Console.ReadLine();
                    correct = Regex.IsMatch(login, @"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");
                    //correct = reg.IsMatch(login);

                    if (!correct) Console.WriteLine("Логин не удвлетворяет требованиям.");

				} while(!correct);
			}

			//if(!correct) Console.WriteLine(result);
		    Console.WriteLine("Логин верный.");
		}
	}
}