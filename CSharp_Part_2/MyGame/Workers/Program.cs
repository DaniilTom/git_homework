using System;

namespace Workers
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] exampleNames = {

				"Иванов Петр",
            	"Петров Иван",
            	"Павлов Александр",
            	"Смирнов Максим",
            	"Васильев Артем",
            	"Попов Никита",
            	"Соколов Дмитрий",
           		"Михайлов Егор",
            	"Федоров Михаил",
            	"Морозов Алексей"
            };

			BaseWorker[] bw = new BaseWorker[10];

			Random rnd = new Random();
            
            // заполнение массива BaseWorker[]
			for(int i = 0; i < bw.Length; i++)
			{
                if (rnd.Next(0, 2) == 1) bw[i] = new FixedSalaryWorker(exampleNames[i], rnd.Next(10, 100));
				else bw[i] = new HourlySalaryWorker(exampleNames[i], rnd.Next(10, 100));
			}

            Console.WriteLine("Исходный массив:\n");
			foreach(var worker in bw) // исходный массив
			{
				Console.WriteLine($"{worker.fullName, -20} {worker.AverageSalaryPerMonth(), 10 : 0.00}");
			}

            Console.WriteLine("\nОтсортированный массив:\n");
			Array.Sort(bw);
			foreach(var worker in bw) // отсортированный массив
			{
				Console.WriteLine($"{worker.fullName, -20} {worker.AverageSalaryPerMonth(), 10 : 0.00}");
			}

            // пример использования перечеслителя
            Console.WriteLine("\nПример использования перечислителя:\n");
			BaseWorkerEnumerator bwEn = new BaseWorkerEnumerator(bw);

			foreach(BaseWorker worker in bwEn)
			{
				Console.WriteLine($"{worker.fullName, -20} {worker.AverageSalaryPerMonth(), 10 : 0.00}");
			}

            Console.WriteLine("\nНажмите Enter, чтобы сгенерировать исключение...");
			Console.ReadLine();

            // object может принимать любые значения
            Object[] ob = new Object[2];

            ob[0] = new FixedSalaryWorker("John Johnson", 100);
            ob[1] = 20;

            try
            {
                Array.Sort(ob);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + " " + e.InnerException.Message);
            }

            Console.ReadLine();
		}
	}
}