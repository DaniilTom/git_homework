using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Interfaces
{
    // очень похож на IServiceEmployeeData, м.б. стоит использовать
    // какой-нибудь один интерфейс
    public interface IServiceMicrocontrollerData
    {
        IEnumerable<ProductBase> Products { get; }

        IEnumerable<MCDescription> DetailedDescription { get; }

        ProductBase GetById(int id);

        void AddNew(ProductBase employee);

        void Delete(int id);

        void SaveChanges();
    }
}
