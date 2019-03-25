using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFiles
{
    class Program
    {
        /// <summary>
        /// Объект синхронизации
        /// </summary>
        static object lock_obj = new object();

        /// <summary>
        /// Список для хранения результатов
        /// </summary>
        static List<double> result = new List<double>();

        static void Main(string[] args)
        {
            var files_names = Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\examples").ToArray(); ;

            ManualResetEvent[] mre = new ManualResetEvent[files_names.Count()];

            // хотел объединить через join, чтоб в foreach потом использовать, но ругается на типы
            //var param_s = files_names.Join(mre, x => x, y => y, (string x, ManualResetEvent y) => new Params{ _file_name = x, _mre = y  });

            for(int i = 0; i < files_names.Count(); i++)
            {
                mre[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(ReadAndExecute, new Params(files_names[i], mre[i]));
            }

            // ожидание конца всех расчетов
            WaitHandle.WaitAll(mre);

            Console.WriteLine("Начало записи в файл...");

            Task writer = new Task(
                ()  =>
                {
                    File.WriteAllLines("result.dat", result.Select(x => x.ToString()));
                });
            writer.RunSynchronously();

            Console.WriteLine("Конец записи.");

            Console.WriteLine("Выполнено");
            Console.ReadLine();
        }

        public static void ReadAndExecute(object param)
        {
            Params par = (Params)param;

            string[] data;

            using (StreamReader sr = new StreamReader(par._file_name))
            {
                data = sr.ReadLine().Split(' ');
            }

            double arg1 = Double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture);
            double arg2 = Double.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture);

            double res = data[0] == "1" ? arg1 * arg2 : arg1 / arg2;

            lock (lock_obj)
            {
                result.Add(res);
            }

            Console.WriteLine($"{par._file_name.Substring(par._file_name.LastIndexOf('\\')), -10}: {data[0], 1} {data[1], 6} {data[2], 6}, результат = {res}");
            
            par._mre.Set();
        }

        /// <summary>
        /// Инкапсулирует параметры
        /// </summary>
        class Params
        {
            public ManualResetEvent _mre;
            public string _file_name;

            public Params() { }

            public Params(string file_name, ManualResetEvent mre)
            {
                _mre = mre;
                _file_name = file_name;
            }
        }
    }
}
