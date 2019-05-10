using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Interfaces.Services;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Implementations
{
    public class ProductDataService : IServiceProductData
    {
        public IEnumerable<ProductBase> Products => TestData.Products;

        public IEnumerable<MCDescription> DetailedDescription => TestData.MCDescriptions;

        // все ниже пока не нужно
        // весь набор данных заранее предопределен
        // эта реализация только для получения данных
        public void AddNewProduct(ProductBase product)
        {
            throw new NotImplementedException();
        }

        public void AddNewDescription(MCDescription description)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ProductBase GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
