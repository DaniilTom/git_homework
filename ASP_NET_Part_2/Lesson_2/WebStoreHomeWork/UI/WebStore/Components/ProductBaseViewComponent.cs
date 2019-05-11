﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;
using WebStore.ViewModel;

namespace WebStore.Components
{
    public class ProductBaseViewComponent : ViewComponent
    {
        private readonly IServiceProductData _MicrocontrollerData;

        public ProductBaseViewComponent(IServiceProductData ProductData)
        {
            _MicrocontrollerData = ProductData;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<MicrocontrollerViewModel> mv_model = GetProducts();
            return View(mv_model);
        }

        private IEnumerable<MicrocontrollerViewModel> GetProducts()
        {
            var mc = _MicrocontrollerData.Products;
            var desc = _MicrocontrollerData.DetailedDescription;

            return from m in mc
                   from d in desc
                   where m.Id == d.ProductId
                   select new MicrocontrollerViewModel {ProductBase = m, MCDescription = d };
        }
    }
}
