using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.controllers
{
    public class EmployesController : Controller
    {
        static string dossier = "Прочая текстовая информация для отображения где-нибудь.";

        private List<Employee> _Employes = new List<WebStore.Models.Employee>()
        {
            new Employee{Id = 1, FirstName = "Иван", SurName = "Иванов", Patronymic = "Иванович", Age = 20},
            new Employee{Id = 2, FirstName = "Вася", SurName = "Васильев", Patronymic = "Васильевич", Age = 25, Dossier = dossier}
        };

        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View(_Employes);
        }

        public IActionResult Details(int id)
        {
            var employe = _Employes.FirstOrDefault(e => e.Id == id);
            if (employe == null) return NotFound();

            return View(employe);
        }

        public IActionResult Dossier(int id)
        {
            var employe = _Employes.FirstOrDefault(e => e.Id == id);
            if (employe == null) return NotFound();

            return View(employe);
        }
    }
}