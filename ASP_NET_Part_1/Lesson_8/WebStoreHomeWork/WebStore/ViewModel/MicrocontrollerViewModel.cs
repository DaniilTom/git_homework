using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.ViewModel
{
    public class MicrocontrollerViewModel
    {
        public ProductBase ProductBase { get; set; }
        public MCDescription DetailedDescription { get; set; }
    }
}
