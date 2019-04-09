using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Interfaces;

namespace WebStore.Domain.Implementations
{
    public class Category : ICategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int TotalProductsCount { get; set; }
    }
}
