using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _db;

        public SqlProductData(WebStoreContext DB)
        {
            _db = DB;
        }

        public IEnumerable<Brand> GetBrands() => _db.Brands.Include(brand => brand.Products).AsEnumerable();

        public IEnumerable<Product> GetProduct(ProductFilter Filter)
        {
            IQueryable<Product> products = _db.Products;
            if (Filter is null)
                return products;
            if (Filter.SectionId != null)
                products = products.Where(product => product.SectionId == Filter.SectionId);

            if (Filter.BrandId != null)
                products = products.Where(product => product.BrandId == Filter.BrandId);

            return products.AsEnumerable();
        }
        

        public IEnumerable<Section> GetSections()
        {
            return _db.Sections.Include(s => s.Products).AsEnumerable();
        }
    }
}
