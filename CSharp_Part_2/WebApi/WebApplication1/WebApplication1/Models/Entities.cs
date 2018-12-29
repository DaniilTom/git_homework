using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace WebApplication1.Models
{
    [DataContract]
    public class Employee
    {
        // считаем, что Employee может работать только в одном Department

        /// <summary>
        /// Первичный ключ.
        /// </summary>
        [DataMember]
        public int Departament_ID { get; set; }


        private Department dep;

        public Employee(string _FullName)
        {
            FullName = _FullName;
            dep = null;
        }

        /// <summary>
        /// Полное имя работника.
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// Содержит ссылку на объект <see cref="Department"/>, к которму прикреплен.
        /// </summary>
        public Department Department
        {
            get
            {
                return dep;
            }
            set
            {
                value.AddEmployee(this);
                dep = value;
                Departament_ID = value.ID;
            }
        }
    }

    [Serializable]
    public class Department
    {
        /// <summary>
        /// Первичный ключ.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Содержит список работников, прикрепленных к текущему <see cref="Department"/>
        /// </summary>
        public List<Employee> empList { get; set; }

        public Department(string _fullName)
        {
            FullName = _fullName;
            empList = new List<Employee>();
        }

        /// <summary>
        /// Содержит название <see cref="Department"/>
        /// </summary>
        [DataMember]
        public string FullName { get; set; }


        //public List<Employee> Employees { get => empList; }

        /// <summary>
        /// Добавляет работника в список.
        /// </summary>
        /// <param name="emp"></param>
        public void AddEmployee(Employee emp)
        {
            if (!empList.Contains(emp))
            {
                if (emp.Department != null) emp.Department.DeleteEmployee(emp); // удаляет Employee из его текущего Department

                empList.Add(emp);
                //emp.Department = this;
            }
        }

        /// <summary>
        /// Удаляет <see cref="Employee"/> из <see cref="Department"/>.
        /// </summary>
        /// <param name="emp"></param>
        private void DeleteEmployee(Employee emp)
        {
            if (empList.Contains(emp))
            {
                empList.Remove(emp);
                //emp.Department = null;
            }
        }
    }

    /// <summary>
    /// Содержит какие-то вспомогательные методы и данные.
    /// </summary>
    static class Support
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

            for (int i = 0; i < fNames.Length; i++)
            {
                for (int j = 0; j < lNames.Length; j++)
                {
                    allEmployees[i * fNames.Length + j] = new Employee(fNames[i] + " " + lNames[j]);
                }
            }

            allEmployees.Shuffle();

            int max_per_dep = allEmployees.Length / depNames.Length;

            int pos = 0;
            for (int i = 0; i < depNames.Length; i++)
            {
                dep[i] = new Department(depNames[i]);
                dep[i].ID = i + 1;
                for (; pos < max_per_dep * (i + 1); pos++)
                {
                    dep[i].AddEmployee(allEmployees[pos]);
                    allEmployees[pos].Department = dep[i];
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

        public static string updateEmployee = @"UPDATE Employee SET Name = @Name, Departament_ID = @Departament_ID WHERE ID = @ID";
        public static string addDepartment = @"INSERT INTO Departament(Name) VALUES(@Name);";
        public static string addEmployee = @"INSERT INTO Employee(Name, Departament_ID) VALUES (@Name, @Departament_ID);";
        public static string selectAllDepartment = @"SELECT * FROM Departament;";
        public static string selectAllEmployees = @"SELECT * FROM Employee;";
        public static string truncateDepartament = @"TRUNCATE TABLE Departament;";
        public static string truncateEmployee = @"TRUNCATE TABLE Employee;";
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True;Pooling=False";
        public static string createTables =
            @"CREATE TABLE[dbo].[Departament1] (
                                    [ID] INT IDENTITY(1, 1) NOT NULL,
                                    [Name] NVARCHAR(50) NOT NULL,
                                    CONSTRAINT[PK_dbo.Departament1] PRIMARY KEY CLUSTERED([Id] ASC)
                                );

CREATE TABLE[dbo].[Employee1] (
                                    [ID] INT IDENTITY(1, 1) NOT NULL,
                                    [Name] NVARCHAR(50) NOT NULL,
									[Departament_ID] INT NOT NULL,
                                    CONSTRAINT[PK_dbo.Employee1] PRIMARY KEY CLUSTERED([Id] ASC)
                                );";
    }
}