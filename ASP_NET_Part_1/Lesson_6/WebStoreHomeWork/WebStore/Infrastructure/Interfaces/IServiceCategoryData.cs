using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IServiceCategoryData
    {
        IEnumerable<Category> GetCategories();
    }
}
