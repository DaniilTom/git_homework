﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Implementations;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IServiceAllData
    {
        private readonly WebStoreContext _db;

        public SqlProductData(WebStoreContext db)
        {
            _db = db;
        }

        public IEnumerable<ProductBase> Products => _db.Products;

        public IEnumerable<MCDescription> DetailedDescription => _db.MCDescriptions;

        public IEnumerable<Category> GetCategories() => _db.Categories;

        public IEnumerable<Order> Orders => _db.Orders.Include(o => o.Items).ThenInclude(i => i.Product).AsEnumerable();

        public IEnumerable<OrderItem> OrderItems => _db.OrderItems;

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

        public void AddNewOrderItem(OrderItem orderItem)
        {
            _db.OrderItems.Add(orderItem);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductBase GetById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}