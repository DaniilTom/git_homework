using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_5
{
	partial class Program
	{
		/* Томашевич
		Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
		а) Вывести только те слова сообщения,  которые содержат не более n букв.
		б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
		в) Найти самое длинное слово сообщения.
		г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
		д) ***Создать метод, который производит частотный анализ текста.
		В качестве параметра в него передается массив слов и текст,
		в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
		Здесь требуется использовать класс Dictionary.
*/

        static void Task2()
        {
            Console.WriteLine("Задача 2. Статически класс Message.");

            string sourceText = "Этот текст содержит набор слов, которые будут обрабатываться " +
                "методами статического класса Message. А здесь несколько повторений: здесь, повторений, текст.";

            Console.WriteLine("\nСлова, которые содержат не более 5 букв:");
            Message.WriteWordsConstraintLength(5, sourceText);

            Console.WriteLine("\nУдаление слов, оканчивающихся на \"т\": ");
            Console.WriteLine(Message.DeleteWordsEndsWith('т', sourceText) + "\n");

            Console.WriteLine("\nСамое длинное слово: {0}", Message.MostLongWordIn(sourceText));

            Console.WriteLine("\nСтрока из самых длинных слов: {0}", Message.MostLongWordsSetFrom(sourceText));

            Console.WriteLine("\nЧастотный анализ текста: ");
            string[] samples = { "текст", "набор", "повторений", "кот" };
            Dictionary<string, int> d = Message.WordsFrequencyAnalysis(samples, sourceText);
            foreach (var elem in d) { Console.WriteLine("{0, 20} {1, 5}", elem.Key, elem.Value); }
        }
		

		static class Message
		{
            /// <summary>
            /// Набор разделителей для поиска слов в тексте.
            /// </summary>
			static char[] seps = {' ', '.', ',', '?', '!', ':', ';', '-'};

            /// <summary>
            /// Получение слов из текста в виде массива строк.
            /// </summary>
            /// <param name="msg">Исходный текст</param>
            /// <returns></returns>
			static string[] GetWordsFrom(string msg)
			{
                //msg = msg.ToLower();
				return msg.Split(seps, StringSplitOptions.RemoveEmptyEntries);
			}
			
            /// <summary>
            /// Выводт слова, длина которых не больше заданной.
            /// </summary>
            /// <param name="length">Максимальная длина слова</param>
            /// <param name="msg">Исходный текст</param>
			public static void WriteWordsConstraintLength(int length, string msg)
			{
				string[] words = GetWordsFrom(msg);

				foreach(var word in words) if(word.Length <= length) Console.WriteLine(word);
			}

            /// <summary>
            /// Удаление всех слов, оканчивающихся на заданный символ.
            /// </summary>
            /// <param name="key">Заданный символ</param>
            /// <param name="msg">Исходный текст</param>
            /// <returns></returns>
			public static string DeleteWordsEndsWith(char key, string msg)
			{
				string[] words = GetWordsFrom(msg);

				StringBuilder newStr = new StringBuilder(msg);

				foreach(var word in words) if(word.EndsWith(key.ToString())) newStr.Replace(word, "");

				return newStr.ToString();
			}

            /// <summary>
            /// Поиск самого длинного слова в тексте.
            /// </summary>
            /// <param name="msg">Исходный текст</param>
            /// <returns></returns>
			public static string MostLongWordIn(string msg)
			{
				string[] words = GetWordsFrom(msg);
				
				string max = words[0];

				for(int i = 1; i < words.Length; i++)
				{
					if(words[i].Length > max.Length) max = words[i];
				}

				return max;
			}

            /// <summary>
            /// Формирование строки из самых длинных слов исходного текста.
            /// </summary>
            /// <param name="msg">Исходный текст</param>
            /// <returns></returns>
			public static string MostLongWordsSetFrom(string msg)
			{
				int maxLength = MostLongWordIn(msg).Length;

				string[] words = GetWordsFrom(msg);

				StringBuilder result = new StringBuilder();

				for(int i = 0; i < words.Length; i++)
				{
					if(words[i].Length == maxLength) result.Append(words[i] + " ");
				}

				//удалаяется последний пробел
				result.Remove(result.Length - 1, 1);

				return result.ToString();
			}

            /// <summary>
            /// Вычисляет частоту вхождения слов словаря в исходный текст.
            /// </summary>
            /// <param name="wordsDictionary">Словарь</param>
            /// <param name="text">Исходный текст</param>
            /// <returns></returns>
			public static Dictionary<string, int> WordsFrequencyAnalysis(string[] wordsDictionary, string text)
			{
				Dictionary<string, int> d = new Dictionary<string, int>();

				for(int i = 0; i < wordsDictionary.Length; i++)
				{
					d.Add(wordsDictionary[i], 0);
				}

				string[] words = GetWordsFrom(text);

				for(int i = 0; i < words.Length; i++)
				{
					if(wordsDictionary.Contains(words[i])) d[words[i]]++;
				}

				return d;

			}
		}
	}
}