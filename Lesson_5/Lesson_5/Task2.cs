namespace Lesson_5
{
	partial class Programm
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
		

		static class Message
		{
			static char[] seps = {' ', '.', ',', '?', '!', ':', ';', '-'};

			static string[] GetWordsFrom(string msg)
			{
				return msg.Split(seps, StringSplitOptions.RemoveEmptyEntries);
			}
			
			public static void WriteWordsConstraintLength(int length, string msg)
			{
				string[] words = GetWordsFrom(msg);

				foreach(var word in words) if(word.Length <= length) Console.WriteLine(word);
			}

			public static string DeleteWordsEndsWith(char key, string msg)
			{
				string[] words = GetWordsFrom(msg);

				StringBuilder newStr = StrinBuilder(msg);

				foreach(var word in words) if(word.EndsWith(key)) newStr.Replace(word, "");

				return newStr.ToString();
			}

			public static string MostLongWordIn(string msg)
			{
				string[] words = GetWordsFrom(msg);
				
				int maxLength = words[0].Length;
				string result = words[0];

				for(int i = 1; i < words.Length; i++)
				{
					if(words[i].Length > maxLength) result = words[i];
				}

				return result;
			}

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

			public static Dictionary<string, int> WordsFrequencyAnalysis(string[] wordsDictionary, string text)
			{
				Dictionary<string, int> d = new Dictionary<string, int>();

				for(int i = 0; i < wordsDictionary.Length; i++)
				{
					d.Add(wordsDictionary[i], 0);
				}

				string[] words = GetWordsFrom(text);

				foreach(var word in words)
				{
					if(wordsDictionary.Contains(word)) d[wordsDictionary]++;
				}

				return d;

			}
		}
	}
}