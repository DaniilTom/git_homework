using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Служит для объединения данных о микроконтроллерах, их описаний и категорий товаров
    /// </summary>
    public interface IServiceAllData : IServiceCategoryData, IServiceProductData
    {
        IEnumerable<Order> Orders { get; }

        IEnumerable<OrderItem> OrderItems { get; }

        void AddNewOrder(Order order);

        void AddNewOrderItem(OrderItem orderItem);

        Order GetOrderById(int Id);
    }
}
