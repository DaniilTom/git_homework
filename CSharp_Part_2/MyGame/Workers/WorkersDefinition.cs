using System;
using System.Collections;
using System.Collections.Generic;

namespace Workers
{
	abstract class BaseWorker : IComparable<BaseWorker>, IComparable
	{
		public string fullName;
		public double salary;

		protected BaseWorker(string _fullName, Int32 _salary)
		{
			fullName = _fullName;
			salary = _salary;
		}

        /// <summary>
        /// Возвращает среднюю месячную зарплату.
        /// </summary>
        /// <returns></returns>
        public abstract double AverageSalaryPerMonth();

        /// <summary>
        /// Реализация обобщенного интерфейса <see cref="IComparable{}"/>.
        /// </summary>
        /// <param name="bw"></param>
        /// <returns></returns>
		public int CompareTo(BaseWorker bw)
		{
			return BaseWorkerComparer(fullName, bw.fullName);
		}

		/// <summary>
        /// Реализация необобщенного интерфейса <see cref="IComparable"/>.
        /// </summary>
        /// <param name="_bw"></param>
        /// <returns></returns>
		public int CompareTo(object _bw)
		{
			int result;

			try
			{
                // надо для выбрасывания исключения при невозможности приведения типов
				BaseWorker bw = (BaseWorker) _bw;

				result = BaseWorkerComparer(fullName, bw.fullName);
			}
			catch(InvalidCastException)
			{
				Console.WriteLine($"Типы {this.GetType()} и {_bw.GetType()} не приводимы.");
				throw; // прекратить исполнение метода
			}

			return result;
		}

        /// <summary>
        /// Конкретная реализация сравнения строк. Используется в CompareTo() и CompareTo<BaseWorker>()
        /// интерфейсов IComparable.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private int BaseWorkerComparer(string s1, string s2)
		{
			// сначала посимвольное сравнение
			for(int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
			{
				if(s1[i] < s2[i]) return -1;
				else if(s1[i] > s2[i]) return 1;
			}

            // если все символы кратчайшей строки совпадают с 
            // началом другой строки, сортировать по длине строк
            if (s1.Length < s2.Length) return -1;
            else if (s1.Length > s2.Length) return 1;
            else return 0; // худший вариант
		}
	}

    //=========================================================================================

    /// <summary>
    /// Класс, описывающий работника с фиксированным окладом. Наследуется от <see cref="BaseWorker"/>.
    /// </summary>
	class FixedSalaryWorker : BaseWorker
	{
		public FixedSalaryWorker(string _fullName, Int32 _salary) : base(_fullName, _salary)
		{ }

		public override double AverageSalaryPerMonth()
		{
			return salary;
		}
	}

    //==========================================================================================

    /// <summary>
    /// Класс, описывающий работника с почасовой зарплатой. Наследуется от <see cref="BaseWorker"/>
    /// </summary>
	class HourlySalaryWorker : BaseWorker
	{
		public HourlySalaryWorker(string _fullName, Int32 _salary) : base(_fullName, _salary)
		{ }

		public override double AverageSalaryPerMonth()
		{
			return salary * 20.8 * 8;
		}
	}

    //=====================================================================================

	// Инкапсулирует массив типа BaseWorker и предоставляет перечислитель для этого массива
    /// <summary>
    /// Класс, описывающий перечислитель объектов в иерархии наследования <see cref="BaseWorker"/>.
    /// Реализует интерфейсы <see cref="IEnumerator{T}"/> и <see cref="IEnumerable"/>.
    /// </summary>
	class BaseWorkerEnumerator : IEnumerator<BaseWorker>, IEnumerable<BaseWorker>, IDisposable
	{
		public BaseWorker[] bw;
		int position = -1;

		public BaseWorkerEnumerator(BaseWorker[] _bw)
		{
			bw = _bw;
		}

		public object Current
		{
			get{ return bw[position];} 
		}

        BaseWorker IEnumerator<BaseWorker>.Current
        {
            get { return bw[position]; }
        }

		public bool MoveNext()
	    {
	        position++;
	        return (position < bw.Length);
	    }

	    public void Reset()
	    {
	        position = -1;
	    }

	    public IEnumerator<BaseWorker> GetEnumerator()
	    {
	    	return this;
	    }

        // требуется при реализации обобщенного интерфейса
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        // Метод заглушка, т.к. требуется реализация IDisposable
        public void Dispose()
        { }

	}
}