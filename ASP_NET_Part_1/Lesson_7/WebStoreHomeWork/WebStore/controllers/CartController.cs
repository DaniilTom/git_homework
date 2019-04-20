using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebStore.Domain.Interfaces;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.controllers
{
    public class CartController : Controller
    {
        private readonly IServiceCart _CartService;
        private readonly IServiceAllData _DataBase;

        public CartController(IServiceCart CartService, IServiceAllData DataBase)
        {
            _CartService = CartService;
            _DataBase = DataBase;
        }

        public IActionResult Cart()
        {
            string _CartName = $"{User.Identity.Name}_cart";
            var cookie = HttpContext.Request.Cookies[_CartName];

            if(cookie is null)
                return View(new Cart());

            return View(JsonConvert.DeserializeObject<Cart>(cookie));
        }

        public IActionResult AddToCart(int id)
        {
            IProduct product = _DataBase.Microcontrollers.FirstOrDefault(m => m.Id == id);
            _CartService.AddToCart(product);
            return RedirectToAction("Cart");
        }

        public IActionResult DecrementProduct(int id)
        {
            IProduct product = _DataBase.Microcontrollers.FirstOrDefault(m => m.Id == id);
            _CartService.DecrementProduct(product);
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            IProduct product = _DataBase.Microcontrollers.FirstOrDefault(m => m.Id == id);
            _CartService.RemoveFromCart(product);
            return RedirectToAction("Cart");
        }
    }
}