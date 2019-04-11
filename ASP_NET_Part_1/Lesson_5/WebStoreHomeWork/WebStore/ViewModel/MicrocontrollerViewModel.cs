using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Implementations;

namespace WebStore.ViewModel
{
    public class MicrocontrollerViewModel
    {
        public Microcontroller Microcontroller { get; set; }
        public MCDescription DetailedDescription { get; set; }
    }
}
