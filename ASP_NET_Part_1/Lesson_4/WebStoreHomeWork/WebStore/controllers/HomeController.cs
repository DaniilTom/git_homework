using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.controllers
{
    
    //[Controller]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}