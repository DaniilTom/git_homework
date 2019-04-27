using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Implementations
{
    public class MicrocontrollerDataService : IServiceMicrocontrollerData
    {
        public IEnumerable<Microcontroller> Microcontrollers => TestData.Microcontrollers;

        public IEnumerable<MCDescription> DetailedDescription => TestData.MCDetailedDescriptions;

        // все ниже пока не нужно
        public void AddNew(Microcontroller employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Microcontroller GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
