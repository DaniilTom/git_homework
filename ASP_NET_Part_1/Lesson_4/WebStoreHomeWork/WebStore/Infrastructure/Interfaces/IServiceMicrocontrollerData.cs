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
        IEnumerable<Microcontroller> Microcontrollers { get; }

        IEnumerable<MCDescription> DetailedDescription { get; }

        Microcontroller GetById(int id);

        void AddNew(Microcontroller employee);

        void Delete(int id);

        void SaveChanges();
    }
}
