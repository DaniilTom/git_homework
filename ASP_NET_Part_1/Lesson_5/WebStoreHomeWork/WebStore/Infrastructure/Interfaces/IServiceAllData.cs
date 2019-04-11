using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Служит для объединения данных о микроконтроллерах, их описаний и категорий товаров
    /// </summary>
    public interface IServiceAllData
    {
        IEnumerable<Microcontroller> Microcontrollers { get; }

        IEnumerable<MCDescription> DetailedDescription { get; }

        IEnumerable<Category> GetCategories { get; }
    }
}
