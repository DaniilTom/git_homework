using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL.Context;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebStore.Domain.Implementations;
using Microsoft.EntityFrameworkCore;

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
            // но при вызове _db.ProductBase.Category.Name
            // выбрасывалось NullReferenceExecption

            var storeHouseVM = from mic in _db.Products
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
            _db.Products.Add(new Domain.Implementations.ProductBase { Name = name, Price = price, CategoryId = int.Parse(catId)});

            _db.SaveChanges();

            return RedirectToAction("StoreHouse");
        }

        [HttpPost]
        public IActionResult AddDescription(int id, string desc)
        {
            string[] format_desc = desc.Split("\r\n", StringSplitOptions.RemoveEmptyEntries) ;

            _db.MCDescriptions.Add(new Domain.Implementations.MCDescription
            {
                ProductId = id,
                DetailedDesriptionList = format_desc
            });

            _db.SaveChanges();
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
            _db.SaveChanges();

            return RedirectToAction("StoreHouse");
        }

        public IActionResult Orders()
        {
            List<Order> orders = _db.Orders.Include(o => o.Items).ThenInclude(i => i.Product).ToList();
            return View(_db.Orders.Select(o => o).AsEnumerable());
        }
    }
}