using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL.Context;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Domain.User.AdminRoleName)]
    public class ToolsController : Controller
    {
        private readonly WebStoreContext _db;

        public ToolsController(WebStoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StoreHouse()
        {
            // сначала в представление передавался контекст БД (т.е. _db)
            // но при вызове _db.Microcontroller.Category.Name
            // выбрасывалось NullReferenceExecption

            var storeHouseVM = from mic in _db.Microcontrollers
                               from cat in _db.Categories
                               where mic.CategoryId == cat.Id
                               select new StoreHouseViewModel { Product = mic, Category = cat};

            var categories = _db.Categories;
            ViewBag.Categories = categories.AsEnumerable();
            ViewData["Cat"] = categories.AsEnumerable();
            return View(storeHouseVM);
        }

        [HttpPost]
        public IActionResult CreateNew(string name, int price, string catId)
        {
            _db.Microcontrollers.Add(new Domain.Implementations.Microcontroller { Name = name, Price = price, CategoryId = int.Parse(catId)});

            _db.SaveChanges();

            return RedirectToAction("StoreHouse");
        }
    }
}