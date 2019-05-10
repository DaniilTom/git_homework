using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Domain.DTO;
using WebStore.Domain.Implementations;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.AllData
{
    public class AllDataClient : BaseClient, IServiceAllData
    {
        public AllDataClient(IConfiguration configuration) : base (configuration, "api/AllDataApi") { }

        public IEnumerable<OrderDTO> Orders => GetOrders().Result;
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var response = await _Client.GetAsync($"{ServiceAddress}/Orders");
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<List<OrderDTO>>().Result;
            return new List<OrderDTO>();
        }

        public IEnumerable<OrderItemDTO> OrderItems => throw new NotImplementedException();

        public IEnumerable<ProductDTO> Products => GetProducts().Result;
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var response = await _Client.GetAsync($"{ServiceAddress}/Products");
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<List<ProductDTO>>().Result;
            return new List<ProductDTO>();
        }

        public IEnumerable<MCDescription> DetailedDescription => throw new NotImplementedException();

        public void AddNewDescription(MCDescription description)
        {
            throw new NotImplementedException();
        }

        public void AddNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void AddNewOrderItem(OrderItemDTO orderItem)
        {
            throw new NotImplementedException();
        }

        public void AddNewProduct(ProductBase product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int Id)
        {
            throw new NotImplementedException();
        }

        public ProductBase GetProductById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
