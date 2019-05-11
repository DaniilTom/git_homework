using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL.Context;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebStore.Domain.Implementations;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.DTO;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Domain.User.AdminRoleName)]
    public class ToolsController : Controller
    {
        private readonly IServiceAllData _db;

        public ToolsController(IServiceAllData db)
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
            // но при вызове _db.ProductBase.Category.Name
            // выбрасывалось NullReferenceExecption

            var storeHouseVM = from mic in _db.Products
                               from cat in _db.Categories
                               where mic.CategoryId == cat.Id
                               select new StoreHouseViewModel { Product = mic, Category = cat};

            var categories = _db.Categories;
            ViewBag.Categories = categories;
            ViewData["Cat"] = categories;
            return View(storeHouseVM);
        }

        [HttpPost]
        public IActionResult CreateNew(string name, int price, string catId)
        {
            _db.AddNewProduct(new ProductDTO { Name = name, Price = price, CategoryId = int.Parse(catId)});

            return RedirectToAction("StoreHouse");
        }

        [HttpPost]
        public IActionResult AddDescription(int id, string desc)
        {
            string[] format_desc = desc.Split("\r\n", StringSplitOptions.RemoveEmptyEntries) ;

            _db.AddNewDescription(new MCDescription
            {
                ProductId = id,
                DetailedDesriptionList = format_desc
            });

            return RedirectToAction("StoreHouse");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImgAsync(IFormFile file, [FromServices] IHostingEnvironment _appEnvironment, int id)
        {
            string path = _appEnvironment.WebRootPath + "/img/" + file.FileName;
            using (var fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(fileStream);
            }
            _db.Products.First(m => m.Id == id).ImageUrl = "/img/" + file.FileName;

            return RedirectToAction("StoreHouse");
        }

        public IActionResult Orders()
        {
            return View(_db.Orders);
        }
    }
}