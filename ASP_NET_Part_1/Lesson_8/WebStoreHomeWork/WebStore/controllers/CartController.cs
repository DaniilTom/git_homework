using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebStore.DAL.Context;
using WebStore.Domain.Implementations;
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

            if (cookie is null)
                return View(new Cart());

            return View(JsonConvert.DeserializeObject<Cart>(cookie));
        }

        public IActionResult AddToCart(int id)
        {
            IProduct product = _DataBase.Products.FirstOrDefault(m => m.Id == id);
            _CartService.AddToCart(product);
            return RedirectToAction("Cart");
        }

        public IActionResult DecrementProduct(int id)
        {
            IProduct product = _DataBase.Products.FirstOrDefault(m => m.Id == id);
            _CartService.DecrementProduct(product);
            return RedirectToAction("Cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            IProduct product = _DataBase.Products.FirstOrDefault(m => m.Id == id);
            _CartService.RemoveFromCart(product);
            return RedirectToAction("Cart");
        }

        public IActionResult Checkout([FromServices] WebStoreContext _db)
        {
            string _CartName = $"{User.Identity.Name}_cart";
            var cookie = HttpContext.Request.Cookies[_CartName];
            Cart cart = JsonConvert.DeserializeObject<Cart>(cookie);

            var order = new Order
            {
                UserName = User.Identity.Name,
                Contact = "1 5 Net Core st.",
                TotalPrice = cart.Items.Sum(pc => pc.Count * pc.Product.Price)
            };

            _db.Orders.Add(order);

            foreach(var item in cart.Items)
            {
                var order_item = new OrderItem
                {
                    Order = order,
                    Product = item.Product,
                    Quantity = item.Count
                };
                _db.OrderItems.Add(order_item);
            }
            
            _db.SaveChanges();

            HttpContext.Response.Cookies.Delete(_CartName);

            return RedirectToAction("Catalog", "Home");
        }
    }
}