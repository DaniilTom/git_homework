using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.controllers.Interfaces;
using WebStore.Models;

namespace WebStore.controllers.Implementations
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        static string dossier = "Прочая текстовая информация для отображения где-нибудь.";

        private List<Employee> _Employes = new List<WebStore.Models.Employee>()
        {
            new Employee{Id = 1, FirstName = "Иван", SurName = "Иванов", Patronymic = "Иванович", Age = 20},
            new Employee{Id = 2, FirstName = "Вася", SurName = "Васильев", Patronymic = "Васильевич", Age = 25, Dossier = dossier}
        };

        public void AddNew(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (_Employes.Contains(employee) || _Employes.Any(e => e.Id == employee.Id)) return;

            employee.Id = _Employes.Count == 0 ? 1 : _Employes.Max(e => e.Id) + 1;
            _Employes.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null) return;
            _Employes.Remove(employee);
        }

        public IEnumerable<Employee> GetAll() => _Employes;

        public Employee GetById(int id) => _Employes.FirstOrDefault(e => e.Id == id);

        public void SaveChanges() { }
    }
}
