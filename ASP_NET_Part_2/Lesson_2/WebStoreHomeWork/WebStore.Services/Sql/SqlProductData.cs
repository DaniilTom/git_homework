using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.DTO;
using WebStore.Domain.Implementations;
using WebStore.Interfaces.Services;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IServiceAllData
    {
        private readonly WebStoreContext _db;

        public SqlProductData(WebStoreContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductDTO> Products
        {
            get
            {
                List<ProductDTO> ProductsDTO = new List<ProductDTO>();
                var products = _db.Products.Include(o => o.Category).AsEnumerable();
                foreach (var product in products)
                {
                    ProductsDTO.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Category = product.Category

                    });
                }
                return ProductsDTO;
            }
        }

        public IEnumerable<MCDescription> DetailedDescription => _db.MCDescriptions;

        public IEnumerable<Category> GetCategories() => _db.Categories;

        public IEnumerable<OrderDTO> Orders
        {
            get
            {
                List<OrderDTO> OrdersDTO = new List<OrderDTO>();
                var orders = _db.Orders.Include(o => o.Items).ThenInclude(i => i.Product).AsEnumerable();
                foreach(var order in orders)
                {
                    OrdersDTO.Add(new OrderDTO
                    {
                        Id = order.Id,
                        UserName = order.UserName,
                        Contact = order.Contact,
                        TotalPrice = order.TotalPrice,
                        Items = order.Items.Select(i => new OrderItemDTO
                        {
                            Id = i.Id,
                            ProductId = i.Product.Id,
                            OrderId = i.Order.Id,
                            Quantity = i.Quantity
                        })
                    });
                }
                return OrdersDTO;
            }
        }

        public IEnumerable<OrderItemDTO> OrderItems
        {
            get
            {
                var o_items = _db.OrderItems;
                return o_items.Select(i => new OrderItemDTO
                {
                    Id = i.Id,
                    ProductId = i.Product.Id,
                    OrderId = i.Order.Id,
                    Quantity = i.Quantity
                });
            }
        }

        public void AddNewProduct(ProductBase prod)
        {
            _db.Products.Add(prod);
            _db.SaveChanges();
        }

        public void AddNewDescription(MCDescription description)
        {
            _db.MCDescriptions.Add(description);
            _db.SaveChanges();
        }

        public void AddNewOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public void AddNewOrderItem(OrderItemDTO orderItem)
        {
            _db.OrderItems.Add(new OrderItem
            {
                Quantity = orderItem.Quantity,
                Order = _db.Orders.FirstOrDefault(o => o.Id == orderItem.OrderId),
                Product = _db.Products.FirstOrDefault(p => p.Id == orderItem.ProductId)
            });
            _db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var prod = _db.Products.FirstOrDefault(p => p.Id == id);
            _db.Products.Remove(prod);
            _db.SaveChanges();
        }

        public ProductBase GetProductById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public Order GetOrderById(int Id)
        {
            return _db.Orders.FirstOrDefault(o => o.Id == Id);
        }
    }
}
