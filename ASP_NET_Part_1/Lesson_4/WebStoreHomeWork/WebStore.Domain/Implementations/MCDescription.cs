using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Interfaces;

namespace WebStore.Domain.Implementations
{
    public class MCDescription : IProductDescription
    {
        public int ProductId { get; set; }
        public string[] DetailedDesriptionList { get; set; }
    }
}
