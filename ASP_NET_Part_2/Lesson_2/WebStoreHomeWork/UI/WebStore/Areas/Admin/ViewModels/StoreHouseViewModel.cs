using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.Areas.Admin.ViewModels
{
    public class StoreHouseViewModel
    {
        public ProductBase Product { get; set; }

        public Category Category { get; set; }
    }
}
