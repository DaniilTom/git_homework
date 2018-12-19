using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfApp1
{
    class Employee
    {
        // считаем, что Employee может работать только в одном Department

        
        public Employee(string _FullName)
        {
            FullName = _FullName;
            Department = null;
        }

        /// <summary>
        /// Полное имя работника.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Содержит ссылку на объект <see cref="Department"/>, к которму прикреплен.
        /// </summary>
        public Department Department { get; set; }
    }

    class Department
    {
        /// <summary>
        /// Содержит список работников, прикрепленных к текущему <see cref="Department"/>
        /// </summary>
        List<Employee> empList = new List<Employee>();

        public Department(string _fullName)
        {
            FullName = _fullName;
        }

        /// <summary>
        /// Содержит название <see cref="Department"/>
        /// </summary>
        public string FullName { get; set; }


        public List<Employee> Employees { get; }

        /// <summary>
        /// Добавляет работника в список.
        /// </summary>
        /// <param name="emp"></param>
        public void AddEmployee(Employee emp)
        {
            if (!empList.Contains(emp))
            {
                empList.Add(emp);
                emp.Department = this;
            }
        }

        /// <summary>
        /// Удаляет <see cref="Employee"/> из <see cref="Department"/>.
        /// </summary>
        /// <param name="emp"></param>
        public void DeleteEmployee(Employee emp)
        {
            if (empList.Contains(emp))
            {
                empList.Remove(emp);
                emp.Department = null;
            }
        }
    }
    
    /// <summary>
    /// Содержит какие-то вспомогательные методы.
    /// </summary>
    static class SupportMethods
    {

        /// <summary>
        /// Создает набор данных Department и Employee
        /// </summary>
        /// <param name="allEmployees"></param>
        /// <returns></returns>
        public static Department[] CreateSet(out Employee[] allEmployees)
        {
            Department[] dep = new Department[depNames.Length];
            allEmployees = new Employee[fNames.Length * lNames.Length];

            for(int i = 0; i < fNames.Length; i++)
            {
                for(int j = 0; j < lNames.Length; j++)
                {
                    allEmployees[i * fNames.Length + j] = new Employee(fNames[i] + " " + lNames[j]);
                }
            }

            allEmployees.Shuffle();

            int max_per_dep = allEmployees.Length / depNames.Length;

            int pos = 0;
            for(int i = 0; i < depNames.Length; i++)
            {
                dep[i] = new Department(depNames[i]);
                for( ; pos < max_per_dep * (i + 1); pos++)
                {
                    dep[i].AddEmployee(allEmployees[pos]);
                }
            }

            return dep;
        }

        // Набор используемых данных
        static string[] depNames = { "Dep. Of Phys", "Dep. Of Math", "Dep. Of Chem", "Dep. Of Bio" };

        static string[] fNames = {
                "Петр",
                "Иван",
                "Александр",
                "Максим",
                "Артем",
                "Никита",
                "Дмитрий",
                "Егор",
                "Михаил",
                "Алексей" };

        static string[] lNames = {
                "Иванов",
                "Петров",
                "Павлов",
                "Смирнов",
                "Васильев",
                "Попов",
                "Соколов",
                "Михайлов",
                "Федоров",
                "Морозов" };

        /// <summary>
        /// Просто разнообразить данные (делает случайную перестановку)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
