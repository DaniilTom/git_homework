using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Services;

namespace WebStore.controllers
{
    
    //[Controller]
    public class HomeController : Controller
    {
        //private readonly IServiceProductData _MicrocontrollerData;

        public HomeController(/*IServiceProductData ProductData*/)
        {
            //_MicrocontrollerData = ProductData;
        }

        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View();
        }

        public IActionResult Contact([FromServices] ILogger<HomeController> log)
        {
            log.LogWarning("Контакты");
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }
    }
}