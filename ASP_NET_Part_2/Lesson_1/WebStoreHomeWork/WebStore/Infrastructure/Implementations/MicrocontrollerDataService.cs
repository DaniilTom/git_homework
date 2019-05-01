using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Implementations
{
    public class ProductDataService : IServiceProductData
    {
        public IEnumerable<ProductBase> Products => TestData.Products;

        public IEnumerable<MCDescription> DetailedDescription => TestData.MCDescriptions;

        // все ниже пока не нужно
        public void AddNewProduct(ProductBase product)
        {
            throw new NotImplementedException();
        }

        public void AddNewDescription(MCDescription description)
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
