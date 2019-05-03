using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Interfaces.Services
{
    // очень похож на IServiceEmployeeData, м.б. стоит использовать
    // какой-нибудь один интерфейс
    public interface IServiceProductData
    {
        IEnumerable<ProductBase> Products { get; }

        IEnumerable<MCDescription> DetailedDescription { get; }

        ProductBase GetById(int id);

        void AddNewProduct(ProductBase product);

        void AddNewDescription(MCDescription description);

        void Delete(int id);
    }
}
