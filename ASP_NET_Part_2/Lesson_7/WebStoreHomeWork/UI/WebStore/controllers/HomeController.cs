using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using WebStore.Interfaces.Services;

namespace WebStore.controllers
{
    
    //[Controller]
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;

        public HomeController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        [DefaultBreadcrumb("Home")]
        public IActionResult Index()
        {
            //return Content("Hello World!!");
            return View();
        }

        [Breadcrumb("Contact")]
        public IActionResult Contact([FromServices] ILogger<HomeController> log)
        {
            log.LogWarning("Контакты");
            return View();
        }

        [Breadcrumb("Catalog", FromAction = "Contact")] //FromAction просто так, посмотреть
        public IActionResult Catalog(int page = 0)
        {
            ViewBag.PageSize = int.Parse(_Configuration["PageSize"]);
            ViewBag.Page = page;
            return View();
        }
    }
}