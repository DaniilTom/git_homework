using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Components
{
    public class MicrocontrollerViewComponent : ViewComponent
    {
        private readonly IServiceMicrocontrollerData _MicrocontrollerData;

        public MicrocontrollerViewComponent(IServiceMicrocontrollerData MicrocontrollerData)
        {
            _MicrocontrollerData = MicrocontrollerData;
        }

        public IViewComponentResult Invoke()
        {
            return View(GetProducts());
        }

        private IEnumerable<MicrocontrollerViewModel> GetProducts()
        {
            var mc = _MicrocontrollerData.Microcontrollers;
            var desc = _MicrocontrollerData.DetailedDescription;

            return from m in mc
                   from d in desc
                   where m.Id == d.ProductId
                   select new MicrocontrollerViewModel {Microcontroller = m, DetailedDescription = d };
        }
    }
}
