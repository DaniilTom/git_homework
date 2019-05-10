using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IServiceEmployeeData
    {
        public EmployeesClient(IConfiguration configuration) : base(configuration, "api/EmployeesApi") { }

        public IEnumerable<Employee> Employees => GetAsync("").Result;

        public async Task<IEnumerable<Employee>> GetAsync(string address)
        {
            var response = await _Client.GetAsync(ServiceAddress + address);
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<List<Employee>>().Result;
            return new List<Employee>();
        }

        public void AddNew(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
