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

        public IEnumerable<Order> Orders() => _db.Orders;

        public IEnumerable<OrderItem> OrderItems() => _db.OrderItems;

        public void AddNew(ProductBase employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductBase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
