using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO;
using WebStore.Domain.Implementations;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AllDataApiController : ControllerBase, IServiceAllData
    {
        private readonly IServiceAllData _DataBase;

        public AllDataApiController(IServiceAllData db)
        {
            _DataBase = db;
        }

        [HttpGet("Orders")]
        public IEnumerable<OrderDTO> GetOrders() // нужен метод для аттрибутов
        {
            return Orders;
        }
        public IEnumerable<OrderDTO> Orders => _DataBase.Orders;

        public IEnumerable<OrderItemDTO> OrderItems => _DataBase.OrderItems;

        [HttpGet("Products")]
        public IEnumerable<ProductDTO> GetProducts()
        {
            return Products;
        }
        public IEnumerable<ProductDTO> Products => _DataBase.Products;

        [HttpGet("Categories")]
        public IEnumerable<Category> GetCategories()
        {
            return _DataBase.GetCategories();
        }

        public IEnumerable<MCDescription> DetailedDescription => _DataBase.DetailedDescription;

        public void AddNewDescription(MCDescription description)
        {
            _DataBase.AddNewDescription(description);
        }

        public void AddNewOrder(Order order)
        {
            _DataBase.AddNewOrder(order);
        }

        public void AddNewOrderItem(OrderItemDTO orderItem)
        {
            _DataBase.AddNewOrderItem(orderItem);
        }

        public void AddNewProduct(ProductBase product)
        {
            _DataBase.AddNewProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _DataBase.DeleteProduct(id);
        }

        public Order GetOrderById(int Id)
        {
            return _DataBase.GetOrderById(Id);
        }

        public ProductBase GetProductById(int Id)
        {
            return _DataBase.GetProductById(Id);
        }
    }
}