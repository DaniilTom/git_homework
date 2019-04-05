using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Infrastructure.Interfaces;
using System.Text;

namespace WebStore.controllers
{
    public class EmployesController : Controller
    {
        IServiceEmployeeData _EmployeesData;

        public EmployesController(IServiceEmployeeData ed)
        {
            _EmployeesData = ed;
        }

        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View(_EmployeesData.Employees);
        }

        public IActionResult Details(int id)
        {
            var employe = _EmployeesData.Employees.FirstOrDefault(e => e.Id == id);
            if (employe == null) return NotFound();

            return View(employe);
        }

        public IActionResult Dossier(int id)
        {
            var employe = _EmployeesData.Employees.FirstOrDefault(e => e.Id == id);
            if (employe == null)
            {
                return NotFound();

                //хотел вместо NotFound() показывать alert() поверх текущего View (без его обновления),
                // но способ снизу загружает новую страницу и исполняет JS
                //string str = "<script>alert(\"Не найдено\");</script>";
                //byte[] b = Encoding.UTF8.GetBytes(str);
                //HttpContext.Response.Body.WriteAsync(b);
            }

            return View(employe);
        }

        public IActionResult Edit(int Id)
        {
            if (Id != 0) return View(_EmployeesData.Employees.First(emp => emp.Id == Id));
            else return View();
        }

        public IActionResult Delete(int id)
        {
            _EmployeesData.Delete(id);
            return Redirect("/Employes/Index");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            if (employee.Id == 0)
            {
                _EmployeesData.AddNew(
                new Employee
                {
                    Id = _EmployeesData.Employees.Count() + 1,
                    FirstName = employee.FirstName,
                    SurName = employee.SurName,
                    Age = employee.Age
                });
            }
            else
            {
                Employee emp = _EmployeesData.Employees.First(e => e.Id == employee.Id);
                emp.FirstName = employee.FirstName;
                emp.SurName = employee.SurName;
                emp.Age = employee.Age;
            }

            return Redirect("/Employes/Index");
        }
    }
}