using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class EmployeesDataService : IServiceEmployeeData
    {
        private List<Employee> _Employees;

        public EmployeesDataService()
        {
            string dossier = "Прочая текстовая информация для отображения где-нибудь.";

            _Employees = new List<Employee>()
            {
                new Employee{Id = 1, FirstName = "Иван", SurName = "Иванов", Patronymic = "Иванович", Age = 20},
                new Employee{Id = 2, FirstName = "Вася", SurName = "Васильев", Patronymic = "Васильевич", Age = 25, Dossier = dossier}
            };
        }

        public IEnumerable<Employee> Employees { get => _Employees; }

        public void AddNew(Employee employee)
        {
            _Employees.Add(employee);
        }

        public void Delete(int id)
        {
            _Employees.Remove(_Employees.FirstOrDefault(e=> e.Id == id));
        }

        public Employee GetById(int id)
        {
            return _Employees.First(e => e.Id == id);
        }

        public void SaveChanges()
        {
            
        }
    }
}
