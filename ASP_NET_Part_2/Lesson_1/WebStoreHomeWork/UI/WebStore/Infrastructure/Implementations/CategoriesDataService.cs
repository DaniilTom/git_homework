using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Domain.Implementations;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class CategoriesDataService : IServiceCategoryData
    {
        public IEnumerable<Category> GetCategories() => TestData.Categories;
    }
}
