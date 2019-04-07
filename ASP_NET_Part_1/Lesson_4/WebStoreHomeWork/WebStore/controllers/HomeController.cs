using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.controllers
{
    
    //[Controller]
    public class HomeController : Controller
    {
        private readonly IServiceMicrocontrollerData _MicrocontrollerData;

        public HomeController(IServiceMicrocontrollerData MicrocontrollerData)
        {
            _MicrocontrollerData = MicrocontrollerData;
        }

        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View(_MicrocontrollerData.Microcontrollers);
        }
    }
}