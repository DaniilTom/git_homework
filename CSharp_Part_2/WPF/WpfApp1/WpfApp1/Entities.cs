using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
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
        static Department[] CreateSet(out Employee[] allEmployees)
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
    }
}
